using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Configurations
{
    public class MongoOptions
    {
        public string DatabaseName { get; set; } = string.Empty;

        public MongoClientSettings ConnectionString { get; set; } = new();
    }
}
