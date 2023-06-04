namespace TodoApi.DTO
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public TodoItemDTO(string description)
        {
            Description = description;
        }
    }
}
