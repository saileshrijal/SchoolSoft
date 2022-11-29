using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<List<T>> GetAll();
        Task Create(T t);
        Task Delete(int id);
        void Edit(T t);
    }
}
