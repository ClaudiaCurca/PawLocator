using System.ComponentModel.DataAnnotations;

namespace PawLocator.Models.DbObjects
{
    public class Update
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public int PostType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
