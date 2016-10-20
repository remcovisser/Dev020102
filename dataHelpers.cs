using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

class DataHepers
{
    Random random;
    public DataHepers(Random random)
    {
        this.random = random;
    }
    
    public string getProjectName()
    {
        List<string> data = new List<string>(new string[]{"project1", "project2", "project3", "project4", "project5", "project6", "project7", "project8", "project9", "project10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public int getBuget()
    {
        return random.Next(1000, 50000);
    }

    public int getAllocatedHours()
    {
        return random.Next(10, 500);
    }

    public int getStreetNumber()
    {
        return random.Next(1, 100);
    }

    public string getStreet()
    {
        List<string> data = new List<string>(new string[]{"street1", "street2", "street3", "street4", "street5", "street6", "street7", "street8", "street9", "street10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getPostalcode()
    {
        List<string> data = new List<string>(new string[]{"postalcode1", "postalcode2", "postalcode3", "postalcode4", "postalcode5", "postalcode6", "postalcode7", "postalcode8", "postalcode9", "postalcode10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getCity()
    {
        List<string> data = new List<string>(new string[]{"city1", "city2", "city3", "city4", "city5", "city6", "city7", "city8", "city9", "city10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getCountry()
    {
        List<string> data = new List<string>(new string[]{"country1", "country2", "country3", "country4", "country5", "country6", "country7", "country8", "country9", "country10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getBuildingName()
    {
        List<string> data = new List<string>(new string[]{"buildingName1", "headquarter2", "headquarter3", "headquarter4", "headquarter5", "headquarter6", "headquarter7", "headquarter8", "headquarter9", "headquarter10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public int getRooms()
    {
        return random.Next(1, 10);
    }

    public int getRent()
    {
        return random.Next(1, 1000);
    }

    public string getFirstName()
    {
        List<string> data = new List<string>(new string[]{"firstname1", "firstname2", "firstname3", "firstname4", "firstname5", "firstname6", "firstname7", "firstname8", "firstname9", "firstname10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getLastName()
    {
        List<string> data = new List<string>(new string[]{"lastName1", "lastName2", "lastName3", "lastName4", "lastName5", "lastName6", "lastName7", "lastName8", "lastName9", "lastName10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getCourse()
    {
        List<string> data = new List<string>(new string[]{"course1", "course2", "course3", "course4", "course5", "course6", "course7", "course8", "course9", "course10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getSchool()
    {
        List<string> data = new List<string>(new string[]{"school1", "school2", "school3", "school4", "school5", "school6", "school7", "school8", "school9", "school10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getLevel()
    {
        List<string> data = new List<string>(new string[]{"level1", "level2", "level3", "level4", "level5", "level6", "level7", "level8", "level9", "level10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public ObjectId getProjectId()
    {
        List<ObjectId> projectIds = database.getProjectIds();
        int index = random.Next(projectIds.Count);
        return projectIds[index];
    }

    public string getPositionName()
    {
        List<string> data = new List<string>(new string[]{"positionName1", "positionName2", "positionName3", "positionName4", "positionName5", "positionName6", "positionName7", "positionName8", "positionName9", "positionName10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public string getPositionDescription()
    {
        List<string> data = new List<string>(new string[]{"positionDescription1", "positionDescription2", "positionDescription3", "positionDescription4", "positionDescription5", "positionDescription6", "positionDescription7", "positionDescription8", "positionDescription9", "positionDescription10"});
        int index = random.Next(data.Count);
        return data[index];
    }

    public int getFee()
    {
        return random.Next(1, 75);
    }

    public int getHours()
    {
        return random.Next(5, 40);
    }
}