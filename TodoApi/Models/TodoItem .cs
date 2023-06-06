namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string DsTodoItem { get; set; }
        public bool Completed { get; set; }
        public TodoItem()
        {
        }
        public TodoItem(string dsTodoItem)
        {
            DsTodoItem = dsTodoItem;
        }
        public TodoItem(string dsTodoItem, bool completed, long id)
        {
            DsTodoItem = dsTodoItem;
            Completed = completed;
            Id = id;
        }
    }
}
