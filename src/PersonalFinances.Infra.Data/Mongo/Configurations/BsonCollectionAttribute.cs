﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Configurations
{
    [AttributeUsage(AttributeTargets.Class, Inherited =false)]
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; }

        public BsonCollectionAttribute(string collectionName) => CollectionName = collectionName;
    }
}
