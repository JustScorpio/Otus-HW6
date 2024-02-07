using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Repositories;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Data
{
    public class MongoDbInitializer
        : IDbInitializer
    {
        private readonly IMongoClient _mongoClient;
        private readonly string _databaseName;

        public MongoDbInitializer(IMongoClient mongoclient, string databaseName)
        {
            _mongoClient = mongoclient;
            _databaseName = databaseName;
        }
        
        public void InitializeDb()
        {
            _mongoClient.DropDatabase(_databaseName);
            var database = _mongoClient.GetDatabase(_databaseName);

            var customers = database.GetCollection<Customer>("customer");
            var preferences = database.GetCollection<Preference>("preference");

            customers.InsertManyAsync(FakeDataFactory.Customers);
            preferences.InsertManyAsync(FakeDataFactory.Preferences);

        }
    }
}