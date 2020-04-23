using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDbSample.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public CreatedUser CreatedUser { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public Post()
        {
        }
        public Post(CreatedUser user,string title)
        {
            CreatedUser = user;
            Title = title;
            Status = new Status();
            CreatedOn = DateTime.UtcNow;
        }

        public Post AddOrRemoveComment(bool isAdd = true)
        {
            if (Status == null)
                Status = new Status();
            Status.NumberOfComments += isAdd ? 1 : -1;
            return this;
        }
        public Post AddOrRemoveLike(bool isAdd = true)
        {
            if (Status == null)
                Status = new Status();
            Status.NumberOfLikes += isAdd ? 1 : -1;
            return this;
        }
        public Post AddOrRemoveShared(bool isAdd = true)
        {
            if (Status == null)
                Status = new Status();
            Status.NumberOfShared += isAdd ? 1 : -1;
            return this;
        }
    }
}
