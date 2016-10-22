using System;
using MongoDB.Bson;

class createProjects
{
    int amount;
    Random random;
    int seed;

    public createProjects (int amount, Random random, int seed)
    {
        this.amount = amount;
        this.random = random;
        this.seed = seed;
    }
    
    public void create()
    {
        DataHepers datahelper = new DataHepers(random);

        for(int i = 0; i < amount; i++)
        {
            Projects project = new Projects
            {
                name = datahelper.getProjectName(),
                budget = datahelper.getBuget(),
                allocatedHours = datahelper.getAllocatedHours(),
                address = new BsonDocument
                {
                    { "streetNumber", datahelper.getStreetNumber() },
                    { "street", datahelper.getStreet() },
                    { "postalcode", datahelper.getPostalcode() },
                    { "city", datahelper.getCity() },
                    { "country", datahelper.getCountry() }
                },
                headquarter = new BsonDocument
                {
                    { "buildingName", datahelper.getBuildingName() },
                    { "rooms", datahelper.getRooms() },
                    { "rent", datahelper.getRent() },
                }
            };

             database.insertProject(project);
        }

        Console.WriteLine(amount + " Projects created with the seed: " + seed);
    } 
}