using System;

namespace VeryDeli.Tests.Integration.TestInfrastructure.PageObjects.Base
{
    public abstract class PageObjectBase
    {
        public IServiceProvider ServiceProvider { get; set; }

        protected PageObjectBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
