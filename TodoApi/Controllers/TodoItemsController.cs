﻿using Microsoft.AspNetCore.Mvc;
using TodoApi.DAO;
using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            try
            {
                List<TodoItem> list = new();

                using (TaskDAO dao = new())
                    list = dao.GetTodoItems();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            try
            {
                TodoItem todoItem;

                using (TaskDAO dao = new())
                    todoItem = dao.GetTodoItem(id);

                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTodoItem(TodoItemDTO data)
        {
            try
            {
                TodoItem todoItem = Mapping.TodoItemMapping.MapToObject(data);

                using TaskDAO dao = new();
                dao.PutTodoItem(todoItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemDTO data)
        {
            long id;
            try
            {
                if (!TodoItemExists(data.DsTodoItem))
                {
                    TodoItem TodoItem = Mapping.TodoItemMapping.MapToObject(data);

                    using (TaskDAO dao = new())
                        id = dao.PostTodoItem(TodoItem);

                    return CreatedAtAction(nameof(GetTodoItem), new { Id = id }, TodoItem);
                }

                return BadRequest("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            try
            {
                using (TaskDAO dao = new())
                    dao.DeleteTodoItem(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private static bool TodoItemExists(string description)
        {
            try
            {
                using TaskDAO dao = new();
                return dao.GetTodoItems().Exists(c => c.DsTodoItem == description);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
