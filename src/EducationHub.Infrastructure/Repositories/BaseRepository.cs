﻿using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;

namespace EducationHub.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _entityCollection;

        public BaseRepository(EducationHubContextDb context)
        {
            _entityCollection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name.FirstCharToLowerCase());
        }

        public async Task InsertOneAsync(TEntity user)
            => await _entityCollection.InsertOneAsync(user);

        public async Task<IEnumerable<TEntity>> FindAsync(FilterDefinition<TEntity> filterDefinition)
        {
            var result = await _entityCollection.FindAsync(filterDefinition);
            return await result.ToListAsync();
        }

        public async Task<TEntity> FindOneAsync(FilterDefinition<TEntity> filterDefinition)
        {
            var result = await _entityCollection.FindAsync(filterDefinition);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<bool> Exists(FilterDefinition<TEntity> filterDefinition)
        {
            var result = await _entityCollection.CountDocumentsAsync(filterDefinition);
            return result > 0;
        }

        public async Task UpdateOneAsync(TEntity entity,
            UpdateDefinition<TEntity> updateDefinition)
        {
            updateDefinition = BaseEntity.SetUpdateDate(updateDefinition);
            await _entityCollection.UpdateOneAsync(entity.GetByIdDefinition<TEntity>(), updateDefinition);
        }

        public async Task UpdateOneAsync(string id,
            UpdateDefinition<TEntity> updateDefinition)
        {
            updateDefinition = BaseEntity.SetUpdateDate(updateDefinition);
            await _entityCollection.UpdateOneAsync(BaseEntity.GetByIdDefinition<TEntity>(id), updateDefinition);
        }

        public async Task UpdateOneAsync(FilterDefinition<TEntity> filterDefinition,
            UpdateDefinition<TEntity> updateDefinition)
        {
            updateDefinition = BaseEntity.SetUpdateDate(updateDefinition);
            await _entityCollection.UpdateOneAsync(filterDefinition, updateDefinition);
        }

        public async Task DeleteOneAsync(string id)
        {
            var filterDefinition = BaseEntity.GetByIdDefinition<TEntity>(id);
            await _entityCollection.DeleteOneAsync(filterDefinition);
        }
    }
}