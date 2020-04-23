using MongoDB.Driver;
using MongoDbSample.Models;

namespace MongoDbSample.Infastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext()
        {
            var client = new MongoClient("<connectionstring>");
            _mongoDb = client.GetDatabase("Facebook");
        }
        public IMongoCollection<Post> Post
        {
            get
            {
                return _mongoDb.GetCollection<Post>(nameof(Models.Post));
            }
        }
    }
}
