using System.ComponentModel.DataAnnotations;

namespace PawLocator.Models.DbObjects
{
    public class Update
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
