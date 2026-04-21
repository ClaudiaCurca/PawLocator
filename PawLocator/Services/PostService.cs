using PawLocator.Models.DbObjects;
using PawLocator.Models;
using PawLocator.Repository;

namespace PawLocator.Services
{
    public class PostService
    {
        private readonly PostRepository repository;

        public PostService(PostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<PostModel>> GetAllAsync()
        {
            var posts = await repository.GetAllAsync();

            return posts.Select(MapToModel).ToList();
        }


        public async Task CreateAsync(PostModel model)
        {
            var entity = MapToEntity(model);

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PostModel model)
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
            existingPost.PostType = (int)model.Type;

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

        private PostModel MapToModel(Post p) => new PostModel
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            Location = p.Location,
            CreatedAt = p.CreatedAt,
            Type = (PostType)p.PostType
        };

        private Post MapToEntity(PostModel m) => new Post
        {
            Id = m.Id == Guid.Empty ? Guid.NewGuid() : m.Id,
            Title = m.Title,
            Description = m.Description,
            ImageUrl = m.ImageUrl,
            Location = m.Location,
            CreatedAt = m.CreatedAt,
            PostType = (int)m.Type
        };
    }
}
