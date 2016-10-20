using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

class database
{
    protected static IMongoClient _client;
    protected static IMongoDatabase _database;

    public static void connect()
    {
        _client = new MongoClient();
        _database = _client.GetDatabase("Assignment2");
    }

    public static void dropCollections()
    {
         _database.DropCollectionAsync("projects");
         _database.DropCollectionAsync("employees");
    }

    public static void insertProject(Projects Project)
    {
        var collection = _database.GetCollection<Projects>("projects");
        collection.InsertOne(Project);
    }

    public static void insertEmployee(Employees employee)
    {
        var collection = _database.GetCollection<Employees>("employees");
        collection.InsertOne(employee);
    }

    public static List<ObjectId> getProjectIds()
    {
        var collection = _database.GetCollection<Projects>("projects");
        var filter = new BsonDocument();
        var results =  collection.Find(filter).ToList();
        List<ObjectId> projectIds = new List<ObjectId>();

        foreach(var result in results)
        {
           projectIds.Add(result._id);
        }

        return projectIds;
    }
}