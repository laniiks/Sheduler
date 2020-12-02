using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction;
using BusinessLogicLayer.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseController
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;

        public TasksController(
            ITasksService tasksService,
            IMapper mapper) : base(mapper)
        {
            _tasksService = tasksService;
            _mapper = mapper;
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> Get(int id)
        {
            var operationResult = await _tasksService.GetById(id);
            return ProcessOperationResult(operationResult);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GeTAll()
        {
            var operationResult = await _tasksService.GetAll();
            return ProcessOperationResult(operationResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TasksCreateRequest tasksCreateRequest)
        {
            var operationResult = await _tasksService
                .Create(_mapper.Map<TasksDto>(tasksCreateRequest));
            return ProcessOperationResult(operationResult);
        }

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var operationResult = await _tasksService.Delete(id);
            return ProcessOperationResult(operationResult);
        }

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="advertisementUpdateRequest">Модель объявления</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TasksUpdateRequest tasksUpdateRequest)
        {
            var operationResult = await _tasksService.Update(_mapper.Map<TasksDto>(tasksUpdateRequest));
            return ProcessOperationResult(operationResult);
        }
    }
}
