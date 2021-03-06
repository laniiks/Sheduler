﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Tasks
{
    public class TasksCreateRequest
    {
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
