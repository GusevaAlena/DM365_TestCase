namespace DM365News.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public string? ImagePath { get; set; }

        public News()
        {
            Id = Guid.NewGuid();
        }
    }
}