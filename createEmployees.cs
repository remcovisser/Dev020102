using System;
using MongoDB.Bson;

class createEmployees
{
    int amount;
    Random random;
    string seed;

    public createEmployees (int amount, Random random, string seed)
    {
        this.amount = amount;
        this.random = random;
        this.seed = seed;
    }
    public void create()
    {
        DataHepers datahelper = new DataHepers(random);

        for (int i = 0; i < amount; i++)
        {
            Employees employee = new Employees
            {
                firstName = datahelper.getFirstName(),
                lastName = datahelper.getLastName(),
                addresses = new BsonDocument
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
                },
                degrees = new BsonDocument
                {
                    { "course", datahelper.getCourse() },
                    { "school", datahelper.getSchool() },
                    { "level", datahelper.getLevel() },
                },
                positions = new BsonDocument
                {
                    datahelper.getPositions()
                }
            };

            database.insertEmployee(employee);
        }

        Console.WriteLine(amount + " Employees created with the seed: " + seed);
    }
}