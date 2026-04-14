using System;
using System.Collections.Generic;

namespace PawLocator.Models.DbObjects
{
    public partial class Post
    {
        public Guid Id { get; set; }
        public Guid? ParentPostId { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
        public int PostType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
