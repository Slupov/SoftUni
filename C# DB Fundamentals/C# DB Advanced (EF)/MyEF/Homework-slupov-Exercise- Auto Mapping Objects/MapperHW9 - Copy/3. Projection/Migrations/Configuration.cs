using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using _3.Projection.Data;
using _3.Projection.Models;

namespace _3.Projection.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeesContext context)
        {
            context.Employees.AddOrUpdate(e => new {e.FirstName, e.LastName, e.Address},
                GenerateManagersWithSubordinates().ToArray());

            context.SaveChanges();
        }

        private static readonly Random rnd = new Random();

        private static readonly List<string> firstNames = new List<string>()
        {
            "Steve",
            "Stephen",
            "Kirilyc",
            "Carl",
            "Moni",
            "Jurgen",
            "Kopp"
        };

        private static readonly List<string> lastNames = new List<string>()
        {
            "Jobbsen",
            "Bjorn",
            "Lefi",
            "Kormac",
            "Straus",
            "Kozinac",
            "Spidok",
        };

        private static readonly List<string> addresses = new List<string>()
        {
            "Tintyava",
            "Bulgaria",
            "Tsarigradsko",
            "GM Dimitrov",
            "Istok",
            "Vasil Levski",
            "6ti Septemvri"
        };

        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(1970, 1, 1);
            int range = (new DateTime(2000, 1, 1) - start).Days;

            if (start < SqlDateTime.MinValue)
            {
                RandomDay();
            }
            return start.AddDays(rnd.Next(range));
        }

        private static Employee GenerateManager(EmployeesContext context)
        {
            return new Employee()
            {
                Address = addresses[rnd.Next(0, addresses.Count)],
                Birthday = RandomDay(),
                Subordinates = new List<Employee>(),
                FirstName = firstNames[rnd.Next(0, firstNames.Count)],
                IsOnHoliday = rnd.Next(0, 2) == 1,
                LastName = lastNames[rnd.Next(0, lastNames.Count)],
                Manager = null,
                Salary = 1000.00m + ((decimal) rnd.NextDouble() * (9000.00m))
            };
        }

        private static Employee GenerateEmployee(Employee manager)
        {
            return new Employee()
            {
                Address = addresses[rnd.Next(0, addresses.Count)],
                Birthday = RandomDay(),
                Subordinates = new List<Employee>(),
                FirstName = firstNames[rnd.Next(0, firstNames.Count)],
                IsOnHoliday = rnd.Next(0, 2) == 1,
                LastName = lastNames[rnd.Next(0, lastNames.Count)],
                Manager = manager,
                Salary = 1000.00m + ((decimal) rnd.NextDouble() * (9000.00m))
            };
        }

        private static IEnumerable<Employee> GenerateManagersWithSubordinates()
        {
            var managers = new List<Employee>();
            using (EmployeesContext context = new EmployeesContext())
            {
                for (int m = 0; m < rnd.Next(1, 4); m++)
                {
                    var manager = GenerateManager(context);

                    //add subordinates to manager
                    for (int i = 0; i < rnd.Next(1, 6); i++)
                    {
                        var emp = GenerateEmployee(manager);
                        manager.Subordinates.Add(emp);
                    }

                    managers.Add(manager);
                }
            }

            return managers;
        }
    }
}