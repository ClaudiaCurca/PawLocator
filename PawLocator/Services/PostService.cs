using PawLocator.Models.DbObjects;
using PawLocator.Repository;
using PawLocator.DTOs;

namespace PawLocator.Services
{
    public class PostService
    {
        private readonly PostRepository repository;

        public PostService(PostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PostDto>> GetAllAsync()
        {
            var posts = await repository.GetAllAsync();

            return posts.Select(MapToModel).ToList();
        }

        public async Task<PostDto?> GetByIdAsync(Guid id)
        {
            var post = await repository.GetByIdAsync(id);

            return post == null ? null : MapToModel(post);
        }

        public async Task CreateAsync(PostDto model)
        {
            var entity = MapToEntity(model);

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PostDto model)
        {
            var existingPost = await repository.GetByIdAsync(model.Id);

            if (existingPost == null)
            {
                return;
            }

            existingPost.Title = model.Title;
            existingPost.Description = model.Description;
            existingPost.ImageUrl = model.ImageUrl;
            existingPost.Location = model.Location;

            await repository.UpdateAsync(existingPost);
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await repository.GetByIdAsync(id);

            if (post == null)
            {
                return;
            }

            await repository.DeleteAsync(post);
        }

        private PostDto MapToModel(Post p) => new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            Location = p.Location,
            CreatedAt = p.CreatedAt,

                    Updates = p.Updates.Select(u => new UpdateDto
                    {
                        Id = u.Id,
                        Message = u.Message,
                        CreatedAt = u.CreatedAt
                    }).ToList()
        
        };

        private Post MapToEntity(PostDto m) => new Post
        {
            Id = m.Id == Guid.Empty ? Guid.NewGuid() : m.Id,
            Title = m.Title,
            Description = m.Description,
            ImageUrl = m.ImageUrl,
            Location = m.Location,
            CreatedAt = m.CreatedAt
        };
    }
}
