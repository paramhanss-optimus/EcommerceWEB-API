using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistance.Repository
{

    public class GenericRepository<T>(EcomerceDBContext context) : IGenericRepo<T> where T : class
    {
        private readonly EcomerceDBContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


       
        public async Task<bool> UpdateAsync(T entity)
        {
            var entityType = typeof(T);
            var keyProperty = entityType.GetProperty("Id");
            if (keyProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an Id property.");
            }

            var keyValue = keyProperty.GetValue(entity);
           

            var existingEntity = await _dbSet.FindAsync(keyValue);
            if (existingEntity == null)
            {
                return false; 
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true; 
        

        //1.	Ensure that the entity has an ID property.
        //2.	Use reflection to get the ID value from the entity.
    }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CreateAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T obj)
        {
            var entity = await _dbSet.FindAsync(obj);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        //public async Task DeleteByExpressionAsync(Expression<Func<T, bool>> predicate)
        //{
        //    var recordsToDelete = await GetByExpressionAsync(predicate);
        //    if (!recordsToDelete.Any())
        //    {
        //        throw new KeyNotFoundException("No records found matching the condition.");
        //    }
        //    _dbSet.RemoveRange(recordsToDelete);
        //    await _context.SaveChangesAsync();
        //}


        //public async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbSet.Where(predicate).ToListAsync();
        //}




    }

}