using PawLocator.DTOs;
using PawLocator.Models.DbObjects;
using PawLocator.Patterns.Factories;
using PawLocator.Repository;

namespace PawLocator.Services
{
    public class UpdateService
    {
        private readonly UpdateRepository repository;
        private readonly IUpdateStrategyFactory factory;

        public UpdateService(UpdateRepository repository, IUpdateStrategyFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }

        public async Task<List<UpdateDto>> GetAllAsync()
        {
            var updates = await repository.GetAllAsync();

            return updates.Select(MapToModel).ToList();
        }

        public async Task<UpdateDto> GetByIdAsync(Guid id)
        {
            var update = await repository.GetByIdAsync(id);

            if(update == null)
            {
                return null;
            }

            return MapToModel(update);
        }

        public async Task CreateAsync(UpdateDto model)
        {
            var strategy = factory.Create(model.Type);

            model.Message = strategy.FormatMessage(model.Message);

            var entity = MapToEntity(model);

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(UpdateDto model)
        {
            var existingUpdate = await repository.GetByIdAsync(model.Id);

            if (existingUpdate == null)
            {
                return;
            }

            existingUpdate.Message = model.Message;

            await repository.UpdateAsync(existingUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var update = await repository.GetByIdAsync(id);

            if (update == null)
            {
                return;
            }

            await repository.DeleteAsync(update);
        }

        private UpdateDto MapToModel(Update p) => new UpdateDto
        {
            Id = p.Id,
            PostId = p.PostId,
            Message = p.Message,
            CreatedAt = p.CreatedAt
        };

        private Update MapToEntity(UpdateDto m) => new Update
        {
            Id = m.Id == Guid.Empty ? Guid.NewGuid() : m.Id,
            PostId = m.PostId,
            Message = m.Message,
            CreatedAt = m.CreatedAt
        };
    }
}
