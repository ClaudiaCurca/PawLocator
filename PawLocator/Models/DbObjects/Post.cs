using System.ComponentModel.DataAnnotations;

namespace PawLocator.Models.DbObjects
{
    public partial class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Update> Updates { get; set; } = new List<Update>();
    }
}
