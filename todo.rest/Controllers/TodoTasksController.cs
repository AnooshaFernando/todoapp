using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.domain.DTO;
using todo.domain.Interface;

namespace todo.rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskHandler _todoTaskHandler;

        public TodoTasksController(ITodoTaskHandler todoTaskHandler)
        {
            this._todoTaskHandler = todoTaskHandler;
        }

        [HttpGet("complete")]
        public async Task<ActionResult<IEnumerable<TodoTaskViewModel>>> GetCompleteTasks()
        {
            try
            {
                var result = await _todoTaskHandler.GetComplete();
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<TodoTaskViewModel>>> GetIncompleteTasks()
        {
            try
            {
                var result = await _todoTaskHandler.GetIncomplete();
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoTaskViewModel>> CreateTask(AddTodoTaskViewModel task)
        {
            try
            {
                var result = await _todoTaskHandler.Add(task);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoTaskViewModel>> EditTask(int id, EditTodoTaskViewModel task)
        {
            try
            {
                var result = await _todoTaskHandler.Edit(id, task);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TodoTaskViewModel>> CompleteTask(int id)
        {
            try
            {
                var result = await _todoTaskHandler.ToggleComplete(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoTaskViewModel>> DeleteTask(int id)
        {
            try
            {
                var result = await _todoTaskHandler.Delete(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception exp)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
