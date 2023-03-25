using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data.Class
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;
      public  IMongoCollection<Product> Products { get => throw new NotImplementedException(); }

        public CatalogContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            var _client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var _database = _client.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);
           var Products = _database.GetCollection<Product>(_configuration["DatabaseSettings:CollectionName"]);
            CatalogContextSeed.SeedData(Products);
        }

    }
}
