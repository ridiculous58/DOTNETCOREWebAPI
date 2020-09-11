using HotelFinder.Core.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Core.Concrete
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T, TId> where T : class,IEntity, new() 
    {

        public async Task<T> Add(T entity)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                context.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(TId entity)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var deleteEntity = context.Find<T>(entity);
                context.Set<T>().Remove(deleteEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                return filter == null ? await context.Set<T>().ToListAsync() : await context.Set<T>().Where(filter).ToListAsync();
            }
            
        }

        public async Task<T> Update(T entity)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
