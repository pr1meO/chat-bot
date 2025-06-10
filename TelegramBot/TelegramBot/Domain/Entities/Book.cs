namespace TelegramBot.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty; 
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Slug { get; set; } = string.Empty;
    }
}
