using Microsoft.VisualBasic;
using System;


namespace PawLocator.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public Guid? ParentPostId { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }

        public PostType Type { get; set; } = PostType.Lost;

        //public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

