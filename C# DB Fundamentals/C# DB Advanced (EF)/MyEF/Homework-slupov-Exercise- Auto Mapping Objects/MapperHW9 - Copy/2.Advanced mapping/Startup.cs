/// <summary>
/// Run several times to get different manager/employee count
/// No database, used randomized seed
/// </summary>
namespace _2.Advanced_mapping
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;

    class Startup
    {
        public static void Main()
        {
            ConfigureAutoMapping();
            IEnumerable<Employee> managers = GenerateManagersWithSubordinates();
            IEnumerable<ManagerDTO> managerDTOs = Mapper.Map<IEnumerable<Employee>, IEnumerable<ManagerDTO>>(managers);

            foreach (var managerDto in managerDTOs)
            {
                Console.WriteLine(managerDto.ToString());
            }

        }

        private static void ConfigureAutoMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDTO>()
                    .ForMember(dto => dto.SubordinatesCount, opt => opt.MapFrom(src => src.Subordinates.Count));
            });
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

        private static Employee GenerateManager()
        {
            return new Employee()
            {
                Address = addresses[rnd.Next(0, addresses.Count)],
                Birthday = new DateTime(rnd.Next(1970, 2000), rnd.Next(1, 13), rnd.Next(1, 31)),
                Subordinates = new List<Employee>(),
                FirstName = firstNames[rnd.Next(0, firstNames.Count)],
                IsOnHoliday = rnd.Next(0, 2) == 1,
                LastName = lastNames[rnd.Next(0, lastNames.Count)],
                Manager = new Employee() {FirstName = "Ivan", LastName = "Ivanov"},
                Salary = 1000.00m + ((decimal) rnd.NextDouble() * (9000.00m))
            };
        }

        private static Employee GenerateEmployee(Employee manager)
        {
            return new Employee()
            {
                Address = addresses[rnd.Next(0, addresses.Count)],
                Birthday = new DateTime(rnd.Next(1970, 2000), rnd.Next(1, 13), rnd.Next(1, 31)),
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
            for (int m = 0; m < rnd.Next(1, 4); m++)
            {
                var manager = GenerateManager();
                //add subordinates to manager
                for (int i = 0; i < rnd.Next(1,6); i++)
                {
                    var emp = GenerateEmployee(manager);
                    manager.Subordinates.Add(emp);
                }

                managers.Add(manager);
            }

            return managers;
        }
    }
}