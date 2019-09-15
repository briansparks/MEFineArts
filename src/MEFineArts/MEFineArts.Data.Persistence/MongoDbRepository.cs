﻿using MEFineArts.Data.Persistence.Interfaces;
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

        public async Task<Guid?> GetUser(string userName, string password)
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

        public async Task<List<Content>> GetContent()
        {
            var collection = mongoClient.GetDatabase(DatabaseName).GetCollection<Content>(ContentCollection);

            var result = await collection.Find(Builders<Content>.Filter.Empty).ToListAsync();

            return result;
        }
    }
}