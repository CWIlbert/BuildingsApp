using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BuildingsApp.Models
{
    public class BuildingDatabaseInitializer : DropCreateDatabaseIfModelChanges<BuildingContext>
    {
        protected override void Seed(BuildingContext context)
        {
            GetBuildings().ForEach(b => context.Buildings.Add(b));
            GetEmployees().ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }
                
        private static List<Building> GetBuildings()
        {
            var buildings = new List<Building> {
                new Building
                {
                    BuildingID = 1,
                    Name = "Dallas Office",
                    Address = "1010 Main Street, Dallas, TX 75201"
                },
                new Building
                {
                    BuildingID = 2,
                    Name = "New York Office",
                    Address = "New York, NY"
                },
                new Building
                {
                    BuildingID = 3,
                    Name = "Chicago Office",
                    Address = "Chicago, IL"
                },
                new Building
                {
                    BuildingID = 4,
                    Name = "Seattle Office",
                    Address = "Seattle, WA"
                },
                new Building
                {
                    BuildingID = 5,
                    Name = "Los Angeles Office",
                    Address = "Los Angeles, CA"
                },
            };

            return buildings;
        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee> {
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "George",
                    LastName = "Washington",
                    Salary = 90000,
                    BuildingID = 1
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "John",
                    LastName = "Adams",
                    Salary =55000,
                    BuildingID = 1
                },
                new Employee
                {
                    EmployeeID = 3,
                    FirstName = "Thomas",
                    LastName = "Jefferson",
                    Salary = 78000,
                    BuildingID = 1
                },
                new Employee
                {
                    EmployeeID = 4,
                    FirstName = "James",
                    LastName = "Madison",
                    Salary = 45000,
                    BuildingID = 1
                },
                new Employee
                {
                    EmployeeID = 5,
                    FirstName = "James",
                    LastName = "Monroe",
                    Salary = 80000,
                    BuildingID = 2
                },
                new Employee
                {
                    EmployeeID = 6,
                    FirstName = "John Quincy",
                    LastName = "Adams",
                    Salary = 75000,
                    BuildingID = 2
                },
                new Employee
                {
                    EmployeeID = 7,
                    FirstName = "Andrew",
                    LastName = "Jackson",
                    Salary = 100000,
                    BuildingID = 2
                },
                new Employee
                {
                    EmployeeID = 8,
                    FirstName = "Martin",
                    LastName = "Van Buren",
                    Salary = 78000,
                    BuildingID = 3
                },
                new Employee
                {
                    EmployeeID = 9,
                    FirstName = "William",
                    LastName = "Harrison",
                    Salary = 85000,
                    BuildingID = 3
                },
                new Employee
                {
                    EmployeeID = 10,
                    FirstName = "John",
                    LastName = "Tyler",
                    Salary = 70000,
                    BuildingID = 3
                },
                new Employee
                {
                    EmployeeID = 11,
                    FirstName = "James",
                    LastName = "Polk",
                    Salary = 85000,
                    BuildingID = 4
                },
                new Employee
                {
                    EmployeeID = 12,
                    FirstName = "Zachary",
                    LastName = "Taylor",
                    Salary = 98000,
                    BuildingID = 4
                },
                new Employee
                {
                    EmployeeID = 13,
                    FirstName = "Millard",
                    LastName = "Fillmore",
                    Salary = 78000,
                    BuildingID = 4
                },
                new Employee
                {
                    EmployeeID = 14,
                    FirstName = "Franklin",
                    LastName = "Pierce",
                    Salary = 65000,
                    BuildingID = 4
                },
                new Employee
                {
                    EmployeeID = 15,
                    FirstName = "James",
                    LastName = "Buchanan",
                    Salary = 100000,
                    BuildingID = 5
                },
                new Employee
                {
                    EmployeeID = 16,
                    FirstName = "Abe",
                    LastName = "Lincoln",
                    Salary = 90000,
                    BuildingID = 5
                },
                new Employee
                {
                    EmployeeID = 17,
                    FirstName = "Andrew",
                    LastName = "Johnson",
                    Salary = 80000,
                    BuildingID = 5
                },
                new Employee
                {
                    EmployeeID = 18,
                    FirstName = "Ulysses",
                    LastName = "Grant",
                    Salary = 75000,
                    BuildingID = null
                },
                new Employee
                {
                    EmployeeID = 19,
                    FirstName = "Rutherford",
                    LastName = "Hayes",
                    Salary = 70000,
                    BuildingID = null
                }
            };

            return employees;
        }
    }
}
