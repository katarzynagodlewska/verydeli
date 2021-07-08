﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VeryDeli.Libraries.Abstraction.Modules;

namespace VeryDeli.Api
{
    public class ModuleLoader
    {
        private const string _modulesFolderPart = "VeryDeli.Modules.";

        public IEnumerable<Assembly> GetModuleAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            var dllModuleFiles = new List<string>();

            foreach (var file in files)
            {
                if (!file.Contains(_modulesFolderPart))
                {
                    continue;
                }

                dllModuleFiles.Add(file);
            }

            dllModuleFiles.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
        }

        public IEnumerable<IModule> GetModules(IEnumerable<Assembly> assemblies)
            => assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
                .OrderBy(x => x.Name)
                .Select(Activator.CreateInstance)
                .Cast<IModule>();
    }
}
