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
            var projectsCollection = _database.GetCollection<Projects>("projects");
            var employeesCollection = _database.GetCollection<Employees>("employees");


            // Delete the old collection
            _database.DropCollectionAsync("projects");

            // Set a seed to create the data
            string seed = "aa12";
            var random = new Random(1);

            // Insert X projects
            createProjects createProjects = new createProjects(projectsCollection, 10, random, seed);
            createProjects.create();

            // Insert Y employees
            //createProjects.create(10, random, seed);

        }
    }
}