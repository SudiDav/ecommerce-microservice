using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration _config)
        {
            var client = new MongoClient(_config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(_config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(_config.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
