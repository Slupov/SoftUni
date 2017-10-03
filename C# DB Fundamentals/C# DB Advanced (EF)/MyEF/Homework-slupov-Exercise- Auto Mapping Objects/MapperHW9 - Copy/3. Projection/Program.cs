using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using _3.Projection.Data;
using _3.Projection.Models;
using AutoMapper.QueryableExtensions;


namespace _3.Projection
{
    class Program
    {
        static void Main()
        {
            ConfigureAutoMapping();
            using (EmployeesContext db = new EmployeesContext())
            {
                var employees =
                    db.Employees.Where(e => e.Birthday.Year < 1990)
                        .OrderByDescending(e => e.Salary)
                        .ProjectTo<EmployeeDto>();

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
        }

        private static void ConfigureAutoMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(e => e.ManagersLastName, opt => opt.MapFrom(src => src.Manager.LastName));
                cfg.CreateMap<Employee, ManagerDTO>()
                    .ForMember(dto => dto.SubordinatesCount, opt => opt.MapFrom(src => src.Subordinates.Count));
            });
        }
    }
}