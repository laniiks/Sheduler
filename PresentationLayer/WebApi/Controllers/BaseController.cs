using System;

using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Метод для проверки результата операции и вывода ошибок.
        /// </summary>
        /// <typeparam name="T">Тип результата</typeparam>
        /// <param name="operationResult">Метод сервиса бизнес слоя</param>
        /// <returns>IActionResult</returns>
        protected IActionResult ProcessOperationResult<T>(OperationResult<T> operationResult)
        {
            if (!operationResult.Success)
            {
                return BadRequest(operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        /// <summary>
        /// Метод для выполнения операции и вывода ошибок. Выполняется асинхронно
        /// </summary>
        /// <typeparam name="T">Тип результата</typeparam>
        /// <param name="serviceAction">Метод сервиса бизнес слоя</param>
        /// <returns>IActionResult</returns>
        protected async Task<IActionResult> ProcessOperationResult<T>(Func<Task<OperationResult<T>>> serviceAction)
        {
            try
            {
                var operationResult = await serviceAction.Invoke();
                if (!operationResult.Success)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
                }

                return Ok(operationResult.Result);
            }
            //catch (BusinessException ex)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
            //catch (EntityNotFoundException ex)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            //}
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
