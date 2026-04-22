using Microsoft.EntityFrameworkCore;
using PawLocator.Data;
using PawLocator.Models.DbObjects;

namespace PawLocator.Repository
{
    public class UpdateRepository : IRepository<Update>
    {
        public ApplicationDbContext dbContext;

        public UpdateRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public UpdateRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Update>> GetAllAsync()
        {
            return await dbContext.Updates.ToListAsync();
        }

        public async Task<Update?> GetByIdAsync(Guid id)
        {
            return await dbContext.Updates.FindAsync(id);
        }

        public async Task AddAsync(Update update)
        {
            await dbContext.Updates.AddAsync(update);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Update update)
        {
            dbContext.Updates.Update(update);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Update update)
        {
            dbContext.Updates.Remove(update);
            await dbContext.SaveChangesAsync();
        }
    }
}
