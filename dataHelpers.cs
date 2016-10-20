using System;
using System.Collections.Generic;


class DataHepers
{
    Random random;
    public DataHepers(Random random)
    {
        this.random = random;
    }

    public string getProjectName()
    {
        List<string> projectNames = new List<string>(new string[]{"project1", "project2", "project3", "project4", "project5", "project6", "project7", "project8", "project9", "project10"});
        int index = random.Next(projectNames.Count);
        return projectNames[index];
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