using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories
{
    public class CrudRepository<T> : IRepository<T> where T : class
    {
        protected readonly VeryDeliDataContext Context;
        private readonly DbSet<T> _table = null;

        public CrudRepository(VeryDeliDataContext context)
        {
            Context = context;
            _table = Context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _table.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public async Task RemoveById(object id)
        {
            var entity = await GetById(id);
            await Remove(entity);
        }

        public async Task Update(T entity)
        {
            _table.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
