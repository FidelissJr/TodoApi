using Dapper;
using System.Data.SqlClient;
using TodoApi.Models;

namespace TodoApi.DAO
{
    public class TaskDAO : IDisposable
    {
        //private readonly string _connectionString;
        
       
        private const string CONNECTION_STRING = @"Server=DESKTOP-DK1E33S\SQLEXPRESS; Database=Todo; Integrated Security=True; trustServerCertificate=true";
        //private const string CONNECTION_STRING = @"Server=192.168.2.184\SQLEXPRESS;Database=Rodoviaria;User Id=sa;Password=sa@123;";
        SqlConnection conn = new(CONNECTION_STRING);
        public TaskDAO()
        {
        }
        public List<TodoItem> GetTasks()
        {
            List<TodoItem> items = conn.Query<TodoItem>("SELECT * FROM TodoItem").ToList();
            return items;
        }
        public TodoItem GetTask(long id)
        {
            TodoItem items = conn.QueryFirstOrDefault<TodoItem>("SELECT * FROM TodoItem WHERE id = @Id", new { Id = id});
            return items;
        }

        public long PostTodoItem(TodoItem todoItem)
        {
            long id = conn.ExecuteScalar<long>("INSERT INTO TodoItem (DsTask) VALUES (@Description)", new { Description =  todoItem.DsTask});
            return id;
        }
        public long PutTodoItem(TodoItem todoItem)
        {
            long id = conn.ExecuteScalar<long>("UPDATE TodoItem SET DsTask = @Description WHERE id = @Id", new { Description = todoItem.DsTask, todoItem.Id });
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
