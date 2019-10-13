using MEFineArts.Data.Persistence.Interfaces;
using MEFineArts.Data.Persistence.DataModels;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MEFineArts.Data.Persistence
{
    public class MongoDBRepository : IRepository
    {
        private static readonly string DatabaseName = "MEFineArts";
        private static readonly string UsersCollection = "Users";
        private static readonly string ContentCollection = "Content";

        private MongoClient mongoClient;

        public MongoDBRepository(string connectionString)
        {
            mongoClient = new MongoClient(connectionString);
        }

        public async Task<string> GetUserAsync(string userName, string password)
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<User>(UsersCollection);
            
            var result = await collection.Find(x => x.Username == userName.ToLower()).ToListAsync();
            var user = result.FirstOrDefault();

            if (user != null)
            {
                if (user.Password == password)
                {
                    return user.AccessToken;
                }
            }

            return null;
        }

        public async Task<List<Content>> GetContentAsync()
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<Content>(ContentCollection);

            var result = await collection.Find(Builders<Content>.Filter.Empty).SortByDescending(x => x.InsertDate).ToListAsync();

            return result;
        }

        public async Task<string> InsertOrUpdateContentAsync(Content content)
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<Content>(ContentCollection);

            var result = await collection.ReplaceOneAsync(x => x.ContentId == content.ContentId, content, new UpdateOptions() { IsUpsert = true });

            return result.UpsertedId?.ToString();
        }

        public async Task<int> InsertOrUpdateContentAsync(List<Content> contentItems)
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<Content>(ContentCollection);

            var writeModels = contentItems.Select(item => new ReplaceOneModel<Content>(new ExpressionFilterDefinition<Content>(x => x.ContentId == item.ContentId), item) { IsUpsert = true });         

            var result = await collection.BulkWriteAsync(writeModels);

            return Convert.ToInt32(result.InsertedCount + result.ModifiedCount);
        }

        public async Task<bool> TryValidateAccessTokenAsync(string accessToken)
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<User>(UsersCollection);

            var filter = Builders<User>.Filter.Eq(x => x.AccessToken, accessToken);

            var users = await collection.Find(filter).ToListAsync();

            return users.Any();
        }

        public async Task DeleteContentAsync(string contentId)
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<Content>(ContentCollection);

            await collection.DeleteOneAsync(x => x.ContentId == contentId);
        }
    }
}
