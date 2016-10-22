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
            int seed = 1;
            var random = new Random(seed);

         
            // Insert X projects
            createProjects createProjects = new createProjects(5, random, seed);
            createProjects.create();

            // Insert Y employees
            createEmployees createEmployees = new createEmployees(10, random, seed);
            createEmployees.create();


            // Output the number of employees that are overworking(more than 20 hours) per project.
            database.totalOverworkingEmployees();

            // Find the total working hours of all employees and the average working hours per employee
            database.totalworkingHoursAndPerEmployee();

            // Find the total fee of an employee. This number is obtained by multiplying the working hours on all the projects by the hour fee of his position.
            database.feePerEmployee();
        }
    }
}