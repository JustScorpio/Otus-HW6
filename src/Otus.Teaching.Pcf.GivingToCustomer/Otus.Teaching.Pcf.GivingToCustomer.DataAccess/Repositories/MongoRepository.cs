using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using MongoDB.Driver;

namespace Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Repositories
{
    public class MongoRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {
        private readonly IMongoCollection<T> _entityCollection;

        public MongoRepository(IMongoCollection<T> entityCollection)
        {
            _entityCollection = entityCollection;
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _entityCollection.Find(x => true).ToListAsync();

            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _entityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            var entities = await _entityCollection.Find(x => ids.Contains(x.Id)).ToListAsync();

            return entities;
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await _entityCollection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _entityCollection.Find(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _entityCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _entityCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _entityCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }
    }
}