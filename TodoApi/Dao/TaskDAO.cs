using Dapper;
using System.Data.SqlClient;
using TodoApi.Models;

namespace TodoApi.DAO
{
    public class TaskDAO : IDisposable
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-DK1E33S\SQLEXPRESS; Database=Todo; User Id=dev; Password=dev@123;";

        SqlConnection conn = new(CONNECTION_STRING);
        public TaskDAO()
        {
        }
        public List<TodoItem> GetTodoItems()
        {
            List<TodoItem> items = conn.Query<TodoItem>("SELECT * FROM TodoItem").ToList();
            return items;
        }
        public TodoItem GetTodoItem(long id)
        {
            TodoItem items = conn.QueryFirstOrDefault<TodoItem>("SELECT * FROM TodoItem WHERE id = @Id", new { Id = id});
            return items;
        }

        public long PostTodoItem(TodoItem todoItem)
        {
            long id = conn.ExecuteScalar<long>("INSERT INTO TodoItem (DsTodoItem) VALUES (@Description)", new { Description =  todoItem.DsTodoItem });
            return id;
        }
        public long PutTodoItem(TodoItem todoItem)
        {
            long id = conn.ExecuteScalar<long>("UPDATE TodoItem SET DsTodoItem = @DsTodoItem, Completed = @Completed WHERE id = @Id", new { todoItem.DsTodoItem, todoItem.Completed, todoItem.Id });
            return id;
        }

        public void DeleteTodoItem(long id)
        {
            conn.Execute("DELETE FROM TodoItem where id = @Id", new { Id = id });
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
