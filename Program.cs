using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication
{
    public class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;


        public static void Main(string[] args)
        {
            // Connect to the database
            _client = new MongoClient();
            _database = _client.GetDatabase("Assignment2");

            // Test insert
            var collection2 = _database.GetCollection<Projects>("projects");
            Projects project = new Projects
            {
                name = "Test project1",
                address =  new BsonDocument
                    {
                        { "street", "3 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
            };

           collection2.InsertOne(project);

            // Test read
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var results =  collection.Find(filter).ToList();

            foreach(var result in results)
            {
                Console.WriteLine(result["address"]["street"].AsString);
            }

        }
    }
}