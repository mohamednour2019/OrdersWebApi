using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Infrastructure.DatabaseContext;
using System.Linq.Expressions;




namespace Orders.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _set;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        /// <summary>
        /// insert entity to dbset with generic type
        /// </summary>
        /// <param name="entity">the entity that will be added to the dbset</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">to be thrown if the input entity is null</exception>
        public async Task InsertAndSaveChangeAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            await _set.AddAsync(entity);
        }



        /// <summary>
        /// update specific entity in dbset with it's id
        /// </summary>
        /// <param name="id">id of the entity that will be updated</param>
        /// <param name="entity">the updated entity that will be replaced by old one</param>
        /// <returns>return the updated entity</returns>
        /// <exception cref="ArgumentNullException">to be thrown if the input entity is null</exception>
        public async Task<T> UpdateAndSave(Guid id, T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _set.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(Guid id, T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _set.Update(entity);
            return entity;
        }


        /// <summary>
        /// delete entity by it's id from dbset
        /// </summary>
        /// <param name="id">the key of the entity to be deleted</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">to be thrown if the input entity is null</exception>
        public async Task<bool> Delete(Guid id)
        {
            T? targetOjbect = await _set.FindAsync(id);
            if (targetOjbect is null)
                return false;
            _set.Remove(targetOjbect);
            await _context.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// delete an entity from dbset with it's key
        /// </summary>
        /// <param name="key">the key of the entity to be deleted from dbset</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">to be thrown if the target entity not resident in dbset</exception>
        public async Task<bool> Delete(object[] key)
        {
            T? target = await _set.FindAsync(key);
            if (target is null)
                return false;
            _set.Remove(target);
            await _context.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// get all entities of specifc type of dbset asynchronously
        /// </summary>
        /// <returns>Ienumerable of entites</returns>
        /// <exception cref="NullReferenceException">to be thrown if dbset is empty</exception>
        public async Task<List<T>> GetAllAsync()
        {
            if (_set is null)
                throw new NullReferenceException();
            return await _set.ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncWithDependents(params string[] includingProperties)
        {
            if (_set is null)
                throw new NullReferenceException();
            if(includingProperties is not null)
            {
                IQueryable<T> query = _set;
                foreach(var param in includingProperties)
                {
                    query.Include(param);
                    return await query.ToListAsync();
                }
            }

            return await GetAllAsync();

        }



        /// <summary>
        /// get a speicif entity with it's key asynchronously
        /// </summary>
        /// <param name="id">the key of the entity to be retrived</param>
        /// <returns>the entity that match the input key</returns>
        /// <exception cref="NullReferenceException">to be thrown if the input entity is not found</exception>
        public async Task<T> GetAsync(Guid id)
        {
            T? result = await _set.FindAsync(id);
            if (result is null)
                throw new NullReferenceException(nameof(result));
            return result;
        }

        /// <summary>
        /// get a speicif entity with it's key asynchronously
        /// </summary>
        /// <param name="key">singe or compund key of the entity to be retrived</param>
        /// <returns>the entity that match the input key</returns>
        /// <exception cref="NullReferenceException">to be thrown if the input entity is not found</exception>
        public async Task<T> GetByCompundKeyAsync(params  Guid [] key)
        {
            T? result = await _set.FindAsync(key);
            if (result is null)
                throw new NullReferenceException(nameof(result));
            return result;
        }

        public Task<List<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            if (condition is null)
                throw new ArgumentNullException(nameof(condition));
            return _set.Where(condition).ToListAsync();
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            if(entities is null)
                throw new ArgumentNullException(nameof(entities));
            await _set.AddRangeAsync(entities);
        }

    }
}
