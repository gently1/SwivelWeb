using Microsoft.EntityFrameworkCore;
using SwivelWeb.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Data.Repository.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

        }
        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingle(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entityToUpdate)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

    }
}
