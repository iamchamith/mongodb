using MongoDB.Driver;
using MongoDbSample.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbSample.Infastructure
{
    public class PostRepository : IBaseRepository<Post>
    {
        MongoDbContext _dbContext;
        public PostRepository(MongoDbContext context)
        {
            _dbContext = context;
        }
        public async Task Add(Post post)
        {
            await _dbContext.Post.InsertOneAsync(post);
        }
        public async Task<Post> GetById(string id)
        {
            FilterDefinition<Post> filter = Builders<Post>.Filter.Eq("Id", id);
            return await _dbContext.Post.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<Post>> Get()
        {
            return await _dbContext.Post.Find(p => true).ToListAsync();
        }
        public async Task<List<Post>> Get(int skip, int take, string searchBy,string searchByTerm, string orderBy, bool orderByTerm)
        {
            FilterDefinition<Post> filter = Builders<Post>.Filter.Eq(searchBy, searchByTerm);

            return await _dbContext.Post.Find(filter)
                //.Skip(skip)
                //.Limit(take)
                .ToListAsync();
        }
        public async Task<List<Post>> GetByUserId(Guid userId)
        {
            FilterDefinition<Post> filter = Builders<Post>.Filter.Eq(p => p.CreatedUser.UserId, userId);

            return await _dbContext.Post.Find(filter)
                .ToListAsync();
        }
        public async Task Update(Post employee)
        {

            await _dbContext.Post.ReplaceOneAsync(filter: g => g.Id == employee.Id, replacement: employee);
        }
        public async Task Delete(string id)
        {

            FilterDefinition<Post> data = Builders<Post>.Filter.Eq("Id", id);
            await _dbContext.Post.DeleteOneAsync(data);
        }
    }
}
