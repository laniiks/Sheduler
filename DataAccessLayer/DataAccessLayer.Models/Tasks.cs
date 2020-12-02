using System;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Идентификатор задач
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Конечное время выполнения
        /// </summary>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// Выполнение задачи
        /// </summary>
        public bool Completed { get; set; }
    }
}
