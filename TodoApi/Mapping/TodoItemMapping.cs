using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Mapping
{
    public class TodoItemMapping
    {
        public static TodoItem MapToObject(TodoItemDTO todoItemDTO)
        {
            return new TodoItem
            {
                DsTask = todoItemDTO.Description,
                Id = todoItemDTO.Id > 0 ? todoItemDTO.Id : 0,
                Completed = todoItemDTO.Completed,
            };
        }
    }
}
