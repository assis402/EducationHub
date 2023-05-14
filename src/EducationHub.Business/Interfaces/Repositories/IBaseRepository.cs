﻿using EducationHub.Business.Entities;
using MongoDB.Driver;

namespace EducationHub.Business.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task InsertOneAsync(TEntity user);

        public Task<TEntity> FindOneAsync(FilterDefinition<TEntity> filterDefinition);

        public Task UpdateAsync(string id, TEntity entity, UpdateDefinition<TEntity> updateDefinition);
    }
}