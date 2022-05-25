using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace WEBAPI_Custom_Exception.DataAccess
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