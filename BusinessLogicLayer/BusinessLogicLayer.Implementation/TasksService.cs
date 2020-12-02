using AutoMapper;
using BusinessLogicLayer.Abstraction;
using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Contracts.Models;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementation
{
    public class TasksService : ITasksService
    {
        private readonly IRepository<Tasks> _tasksRepository;
        private readonly IMapper _mapper;

        public TasksService(
            IRepository<Tasks> tasksRepository,
            IMapper mapper) 
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Create(TasksDto tasksModel)
        {
            var tasks = _mapper.Map<Tasks>(tasksModel);
            await _tasksRepository.Add(tasks);
            await _tasksRepository.SaveChanges();
            return OperationResult<int>.Ok(tasks.Id);
        }

        public async Task<OperationResult<bool>> Delete(int tasksId)
        {
            try
            {
                var tasks = await _tasksRepository.GetById(tasksId);
                await _tasksRepository.Delete(tasks);
                await _tasksRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(new[] { ex.Message });
            }

            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<ICollection<TasksDto>>> GetAll()
        {
            ICollection<Tasks> tasks;

            tasks = await _tasksRepository.GetAll();
      
            return OperationResult<ICollection<TasksDto>>.Ok(_mapper.Map<ICollection<TasksDto>>(tasks));
        }

        public async Task<OperationResult<TasksDto>> GetById(int id)
        {
            var tasks = await _tasksRepository.GetById(id);
            return OperationResult<TasksDto>.Ok(_mapper.Map<TasksDto>(tasks));
        }

        public async Task<OperationResult<int>> Update(TasksDto tasksModel)
        {
            try
            {
                var tasks = await _tasksRepository.GetById(tasksModel.Id);
                _mapper.Map(tasksModel, tasks);
                await _tasksRepository.Update(tasks);
                await _tasksRepository.SaveChanges();
                return OperationResult<int>.Ok(tasks.Id);
            }
            catch(Exception ex)
            {
                return OperationResult<int>.Failure(new[] { ex.Message });
            }
            
        }
    }
}
