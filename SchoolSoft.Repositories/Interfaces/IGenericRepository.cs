using System.Linq.Expressions;


namespace SchoolSoft.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<List<T>> GetAll();
        Task Create(T t);
        public Task Delete(int id);
        void Edit(T t);
        public Task<T?> GetBy(Expression<Func<T, bool>> predicate);
    }
}
