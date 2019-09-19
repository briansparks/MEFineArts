using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MEFineArts.Data.Persistence.DataModels
{
    [BsonIgnoreExtraElements]
    public class Content
    {
        public ObjectId Id { get; set; }
        public string Page { get; set; }
        public string ContentId { get; set; }
        public string ContentType { get; set; }
        public string Value { get; set; }
    }
}
