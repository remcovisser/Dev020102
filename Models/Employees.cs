using MongoDB.Bson;

public class Employees
{
   public string firstName { get; set; }
   public string lastName { get; set; }
   public BsonDocument headquarter {get; set; }
   public BsonDocument addresses { get; set; }
   public BsonDocument degrees {get; set; }
   public BsonDocument positions {get; set; }
}


/*

id [
    firstName
    lastName
    headquarter [
        buildingName 
        rooms
        rent
    ]
    addresses [
        id [
            number
            postalcode
            street
            city
            country
            residence
        ]
    ]
    degrees [
        id [
            course
            school
            level
        ]
    ]
    positions [
        id [
            project_id
            name
            description
            fee
            hours
        ]
    ]
]

*/