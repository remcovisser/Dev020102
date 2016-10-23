using System;
using System.Threading.Tasks;
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


    public static void totalOverworkingEmployees()
    {
        // Get the employees collection
        var employees = _database.GetCollection<BsonDocument>("employees");

        // Get only the employees that are working more dan 20 hours
        BsonJavaScript map = "function() { " +
            "if(this.projects.positions.hours > 20) { " +
                "emit(this.projects.project_id, {count : 1}); " + 
            "}" + 
        "}";

        // Group the overworking employees by project_id
        BsonJavaScript reduce = "function(key, values) {" +
            "var result = {count: 0};" +
            "values.forEach(" +
                "function(value) {" +
                    "result.count ++;" +
                "}" +
            ");" +
            "return result;" +
        "}";

        // Set the MapReduce options
        var options = new MapReduceOptions<BsonDocument, BsonDocument>();
        options.OutputOptions = MapReduceOutputOptions.Inline;

        // Excute map and reduce functions 
        var resultMR = employees.MapReduce(map, reduce, options).ToList();

        // Print the results
        foreach (var result in resultMR)
        {
            Console.WriteLine("Project: " + result["_id"] + " has " + result["value"]["count"] + " overworking employees");
        }
    }

    public static void totalworkingHoursAndPerEmployee()
    {
        // Get the employees collection
        var employees = _database.GetCollection<BsonDocument>("employees");

        // Get the hours per employee
        BsonJavaScript map = "function() { " +
            "emit('total', {employees: 1, hours : this.projects.positions.hours}); " + 
        "}";

        // Get the total hours and employees
        BsonJavaScript reduce = "function(key, values) {" +
            "var result = {employees: 0, hours: 0};" +
            "values.forEach(" +
                "function(value) {" +
                    "result.employees += value.employees;" +
                    "result.hours += value.hours;" +
                "}" +
            ");" +
            "return result;" +
        "}";

        // Set the MapReduce options
        var finalize = "function(key,value){ value.averageHours = value.hours / value.employees; return value;}";
        var options = new MapReduceOptions<BsonDocument, BsonDocument>();
        options.OutputOptions = MapReduceOutputOptions.Inline;
        options.Finalize = finalize;

        // Excute map and reduce functions 
        var resultMR = employees.MapReduce(map, reduce, options).ToList();

        // Print the results
        Console.WriteLine("Employees: " + resultMR[0]["value"]["employees"] + ", hours: " + resultMR[0]["value"]["hours"] + ", avarage: " + resultMR[0]["value"]["averageHours"]);       
    }

    public static void feePerEmployee()
    {
        // Get the employees collection
        var employees = _database.GetCollection<BsonDocument>("employees");

        // Get all the employees with there id, hours and fee
        BsonJavaScript map = "function() { " +
            "emit(this._id, {hours : this.projects.positions.hours, fee: this.projects.positions.fee}); " + 
        "}";

        // Get the total hours and fee per employees
        BsonJavaScript reduce = "function(key, values) {" +
            "var result = {hours: 0, fee: 0};" +
            "values.forEach(" +
                "function(value) {" +
                    "result.hours = value.hours;" +
                    "result.fee += value.fee;" +
                "}" +
            ");" +
            "return result;" +
        "}";

        // Set the MapReduce options
        var finalize = "function(key,value){ value.totalFee = value.hours * value.fee; return value;}";
        var options = new MapReduceOptions<BsonDocument, BsonDocument>();
        options.OutputOptions = MapReduceOutputOptions.Inline;
        options.Finalize = finalize;

        // Excute map and reduce functions 
        var resultMR = employees.MapReduce(map, reduce, options).ToList();

        // Print the results
        foreach (var result in resultMR)
        {
            Console.WriteLine("employee: " + result["_id"] + ", hours: " + result["value"]["hours"] + ", fee: " + result["value"]["fee"] + ", totalFee: " + result["value"]["totalFee"]);
        }
    }
}