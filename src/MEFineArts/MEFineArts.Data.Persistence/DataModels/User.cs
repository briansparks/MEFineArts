using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MEFineArts.Data.Persistence.DataModels
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid AccessToken { get; set; }
    }
}
