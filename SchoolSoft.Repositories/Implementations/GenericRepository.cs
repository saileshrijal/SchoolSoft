using Microsoft.EntityFrameworkCore;
using SchoolSoft.Repositories.Interfaces;
using SchoolSoft.Data;
using System.Linq.Expressions;
using SchoolSoft.Models;

namespace SchoolSoft.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext _context;
        private readonly DbSet<T> entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        virtual public async Task Create(T t)
        {
            await entities.AddAsync(t);
        }

        virtual public async Task Delete(int id)
        {
            var entity = await entities.FindAsync(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }
        }

        virtual public void Edit(T t)
        {
            entities.Update(t);
        }

        virtual public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        virtual public async Task<T?> GetBy(Expression<Func<T, bool>> predicate)
        {
            return await entities.FirstOrDefaultAsync(predicate);
        }

    }
}
