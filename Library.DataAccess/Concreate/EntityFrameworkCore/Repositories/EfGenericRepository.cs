using Library.DataAccess.Interfaces;
using Library.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDAL<TEntity> where TEntity:class,ITable,new()
    {
        public async Task AddAsync(TEntity entity)
        {
            var context = new ApplicationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            var context = new ApplicationDbContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var context = new ApplicationDbContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            var context = new ApplicationDbContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            var context = new ApplicationDbContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();

        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, System.Linq.Expressions.Expression<Func<TEntity, TKey>> keySelector)
        {
            var context = new ApplicationDbContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var context = new ApplicationDbContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var context = new ApplicationDbContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var context = new ApplicationDbContext();
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
