using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interface
{
    public interface IGenericRepo<T> where T : class    {
        Task <bool> CreateAsync(T obj);
        Task<bool> DeleteAsync(T obj);
        Task<bool> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();

        //Task DeleteByExpressionAsync(Expression<Func<T, bool>> predicate);
        //Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> predicate);


        Task SaveChangesAsync();


    }
}


