using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Mapping
{
    public class TodoItemMapping
    {
        public static TodoItem MapToObject(TodoItemDTO todoItemDTO)
        {
            return new TodoItem(todoItemDTO.DsTodoItem, todoItemDTO.Completed, todoItemDTO.Id);
        }
    }
}
