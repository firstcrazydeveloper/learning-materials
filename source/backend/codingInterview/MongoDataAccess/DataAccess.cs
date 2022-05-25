using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CodingInterview.MongoDataAccess
{
    public class DataAccess
    {
        IMongoClient _client;
        IMongoDatabase _db;
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("KabaddiDB");
        }
    }
}
