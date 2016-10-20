using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Connect to the database
            database.connect();
            database.dropCollections();

            // Set a seed to create the data
            string seed = "aa12";
            var random = new Random(1);

            // Insert X projects
            createProjects createProjects = new createProjects(100, random, seed);
            createProjects.create();

            // Insert Y employees
            createEmployees createEmployees = new createEmployees(10000, random, seed);
            createEmployees.create();
        }
    }
}