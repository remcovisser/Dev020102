using MongoDB.Bson;

public class Projects
{
    public ObjectId _id {get; set; }
    public string name { get; set; }
    public int budget { get; set; }
    public int allocatedHours { get; set; }
    public BsonDocument address { get; set; }
    public BsonDocument headquarter {get; set; }
}

/*

id [
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