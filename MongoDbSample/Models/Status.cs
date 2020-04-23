namespace MongoDbSample.Models
{
    public class Status
    {
        public int NumberOfComments { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfShared { get; set; }

        public Status AddOrRemoveComment(bool isAdd = true) {

            NumberOfComments += isAdd ? 1 : -1;
            return this;
        }
        public Status AddOrRemoveLike(bool isAdd = true)
        {

            NumberOfLikes += isAdd ? 1 : -1;
            return this;
        }
        public Status AddOrRemoveShared(bool isAdd = true)
        {

            NumberOfShared += isAdd ? 1 : -1;
            return this;
        }
    }
}
