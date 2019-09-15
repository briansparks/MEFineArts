using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEFineArts.Data.Persistence.DataModels
{
    [BsonIgnoreExtraElements]
    public class Content
    {
        public string Page { get; set; }
        public string ContentId { get; set; }
        public string ContentType { get; set; }
        public string Value { get; set; }
    }
}
