using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbSample.Models
{
    public class CreatedUser
    {
        public Guid UserId { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }

        public CreatedUser(Guid userid,string profileImage,string name)
        {
            UserId = userid;
            ProfileImage = profileImage;
            Name = name;
        }
        public CreatedUser()
        {
        }
    }
}
