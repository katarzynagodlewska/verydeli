using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Libraries.Abstraction.Repository;

namespace VeryDeli.Libraries.Infrastructure.Repository
{
    public abstract class CrudRepository<T, TK> : IRepository<T, TK> where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _table;

        protected CrudRepository(DbContext context)
        {
            Context = context;
            _table = Context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public async Task<T> GetById(TK id)
        {
            var model = await _table.FindAsync(id);

            foreach (var reference in Context.Entry(model).References)
                await reference.LoadAsync();

            return model;
        }

        public async Task Remove(T entity)
        {
            _table.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveById(TK id)
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
