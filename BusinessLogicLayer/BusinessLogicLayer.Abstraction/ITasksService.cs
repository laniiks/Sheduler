using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstraction
{
    public interface ITasksService
    {
        Task<OperationResult<int>> Create(TasksDto tasksModel);
        Task<OperationResult<ICollection<TasksDto>>> GetAll();
        Task<OperationResult<TasksDto>> GetById(int id);
        Task<OperationResult<int>> Update(TasksDto tasksModel);
        Task<OperationResult<bool>> Delete(int tasksId);
    }
}