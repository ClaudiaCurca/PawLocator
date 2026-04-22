using Microsoft.EntityFrameworkCore;
using PawLocator.Data;
using PawLocator.Models.DbObjects;

namespace PawLocator.Repository
{
    public class PostRepository : IRepository<Post>
    {
        public ApplicationDbContext dbContext;

        public PostRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public PostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await dbContext.Posts.FindAsync(id);
        }

        public async Task AddAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post entity)
        {
            dbContext.Posts.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post entity)
        {
            dbContext.Posts.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
