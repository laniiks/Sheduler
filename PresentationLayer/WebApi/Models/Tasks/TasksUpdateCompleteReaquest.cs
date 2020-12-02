using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Tasks
{
    public class TasksUpdateCompleteReaquest
    {
        /// <summary>
        /// Идентификатор задач
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Выполнение задачи
        /// </summary>
        public bool Completed { get; set; }
    }
}
