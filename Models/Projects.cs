using System;
using MongoDB.Bson;

public class Projects
{
   public ObjectId project_id { get; set; }
   public string name { get; set; }
   public int budget { get; set; }
   public int allocatedHours { get; set; }
    public string buildingName {get; set; }
   public BsonDocument address { get; set; }
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