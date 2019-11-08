using CatelogMicroAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatelogMicroAPI.Infra
{
    public class CatalogDbContext
    {
        private IConfiguration configuration;
        private IMongoDatabase mongoDatabase;

        public CatalogDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetValue<string>("MongoSettings:ConnectionString");
            MongoClientSettings mongoClientSetting = MongoClientSettings.FromConnectionString(connectionString);
            MongoClient mongoClient = new MongoClient();
            if(mongoClient != null)
            {
                var databaseString = configuration.GetValue<string>("MongoSettings:Database");
                this.mongoDatabase = mongoClient.GetDatabase(databaseString);
            }
        }

        public IMongoCollection<CatelogItem> Catelog
        {
            get { return this.mongoDatabase.GetCollection<CatelogItem>("products"); }
        }
    }
}
