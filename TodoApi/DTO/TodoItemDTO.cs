namespace TodoApi.DTO
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string DsTodoItem { get; set; }
        public bool Completed { get; set; }
        public TodoItemDTO(string description)
        {
            DsTodoItem = description;
        }
        public TodoItemDTO() { }
    }
}
