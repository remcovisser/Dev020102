using System;
using MongoDB.Bson;

public class Projects
{
   public ObjectId id { get; set; }
   public string name { get; set; }
   public string budget { get; set; }
   public string allocatedHours { get; set; }
   public BsonDocument address { get; set; }
   public string buildingName {get; set; }
}