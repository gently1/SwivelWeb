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
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var propList = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var includeProperty in propList)
            {
                query = query.Include(includeProperty);
            }


            return await query.ToListAsync();
        }

        public async Task<T> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var propList = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var includeProperty in propList)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);

            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public async Task<int> Delete(Expression<Func<T, bool>> filter)
        {
            T entityToDelete = await dbSet.FirstOrDefaultAsync(filter);
            Delete(entityToDelete);
            return 1;
        }

        public void Delete(T entityToDelete)
        {
            if (entityToDelete != null)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

    }
}
