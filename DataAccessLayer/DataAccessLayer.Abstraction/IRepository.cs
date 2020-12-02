using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    /// <summary>
    /// Абстракция базового репозитория
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Получить по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Получить все элементы
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAll();
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Add(T entity);
        /// <summary>
        /// Обновить элемент
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(T entity);
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(T entity);
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();
    }
}
