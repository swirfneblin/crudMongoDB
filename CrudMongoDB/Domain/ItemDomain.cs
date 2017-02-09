using CrudMongoDB.Models;
using MongoDB.Driver;
using System.Configuration;
using System;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CrudMongoDB.Domain
{
    public class ItemDomain
    {
        private IMongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private string _conexaoMongoDB;

        public ItemDomain()
        {
            _conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString;
            _mongoClient = new MongoClient(_conexaoMongoDB);
            _mongoDatabase = _mongoClient.GetDatabase("teste");
        }
     
        public IMongoCollection<Item> Itens
        {
            get
            {
                var itens = _mongoDatabase.GetCollection<Item>("objetos");
                return itens;
            }
        }

        public Item Get(string id)
        {
            var filter = Builders<Item>.Filter.Eq(i => i.Id, id);
            return Itens.Find(filter).First();
        }

        public void Create(Item item)
        {
            Itens.InsertOne(item);
        }

        public void Save(Item item)
        {   
            var filter = Builders<Item>.Filter.Eq(i => i.Id, item.Id);
            var result = Itens.ReplaceOne(filter, item);
        }

        public List<Item> GetAll()
        {
            var filter = new BsonDocument();
            return Itens.Find(filter).ToList();
        }

        public void Remove(string id)
        {
            var filter = Builders<Item>.Filter.Eq(i => i.Id, id);
            var del = Itens.DeleteOne(filter);
        }
    }
}