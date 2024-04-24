using Orders.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.RepositoryContracts
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<List<T>>GetByCondition(Expression<Func<T, bool>> condition);   
        Task<T> GetByCompundKeyAsync(params Guid [] key);
        Task<bool> Delete(Guid id);
        Task<bool> Delete(object[] key);
        Task<T> UpdateAndSave(Guid id, T entity);
        Task InsertAndSaveChangeAsync(T entity);

        Task<List<T>> GetAllAsyncWithDependents(params string[] includingProperties);

        Task<T> Update(Guid id, T entity);
    }
}
