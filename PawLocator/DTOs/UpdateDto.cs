namespace PawLocator.DTOs
{
    public class UpdateDto
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Type { get; set; }
    }
}
