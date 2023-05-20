using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using MongoDB.Driver;

namespace EducationHub.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _entityCollection;

        public BaseRepository(EducationHubContextDb context)
        {
            _entityCollection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
        }

        public async Task InsertOneAsync(TEntity user)
            => await _entityCollection.InsertOneAsync(user);

        public async Task<TEntity> FindOneAsync(FilterDefinition<TEntity> filterDefinition)
        {
            var result = await _entityCollection.FindAsync(filterDefinition);
            return await result.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id,
            TEntity entity,
            UpdateDefinition<TEntity> updateDefinition)
        {
            await _entityCollection.UpdateOneAsync(entity.GetByIdDefinition<TEntity>(id), updateDefinition);
        }
    }
}