namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string DsTask { get; set; }
        public bool Completed { get; set; }
        public TodoItem(string dsTask)
        {
            DsTask = dsTask;
        }

        public TodoItem()
        {

        }

    }
}
