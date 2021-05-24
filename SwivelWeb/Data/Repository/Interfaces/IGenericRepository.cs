using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Data.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<T> GetSingle(Expression<Func<T, bool>> filter = null,  string includeProperties = "");
        Task<T> GetByID(int id);
        void Insert(T entity);
        Task<int> Delete(Expression<Func<T, bool>> filter);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        Task<int> Save();
    }
}
