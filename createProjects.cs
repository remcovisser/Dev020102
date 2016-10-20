using System;
using MongoDB.Bson;
using MongoDB.Driver;

class createProjects
{
    IMongoCollection<Projects> collection;
    int amount;
    Random random;
    string seed;

    public createProjects (IMongoCollection<Projects> collection, int amount, Random random, string seed)
    {
        this.amount = amount;
        this.random = random;
        this.seed = seed;
        this.collection = collection;
    }
    public void create()
    {
        DataHepers datahelper = new DataHepers(random);

        for(int i = 0; i < amount; i++)
        {
            Projects project = new Projects
            {
                name = datahelper.getProjectName(),
                address = new BsonDocument
                    {
                        { "street", "3 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
            };

            insertProject(project);
        }

        Console.WriteLine(amount + " Projects created with the seed: " + seed);
    }

    private void insertProject(Projects project)
    {
         collection.InsertOne(project);
    }

}

/*

project_id [
    name
    budget
    allocatedHours
    address [
        number
        postalcode
        street
        city
        country
    ]
    headquarter [
        buildingName 
        rooms
        rent
    ]
]

*/