using DataAccessLayer.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Repositories
{
    /// <summary>
    /// Реализация базового репозитория
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected readonly ShedulerDbContext _dbContext;
        /// <summary>
        /// Сущность базы данных
        /// </summary>
        protected readonly DbSet<T> _entity;
        /// <summary>
        /// Конструктор базового репозитория
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(ShedulerDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }
        
        public async Task<T> Add(T entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public Task Delete(T entity)
        {
            _entity.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _entity.ToArrayAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task SaveChanges() => await _dbContext.SaveChangesAsync();

        public async Task<T> Update(T entity)
        {
            _entity.Update(entity);
            return entity;
        }
    }
}
