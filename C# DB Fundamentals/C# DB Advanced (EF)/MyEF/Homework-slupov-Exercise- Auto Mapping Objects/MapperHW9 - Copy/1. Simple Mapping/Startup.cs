using System;
using AutoMapper;

namespace _1.Simple_Mapping
{
    class Startup
    {
        static void Main()
        {
            Employee Guy = new Employee
            {
                Address = "ul.Rakovski",
                FirstName = "Guy",
                LastName = "Gilbert",
                Salary = 1500.50m
            };

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dto => dto.Salary, opt => opt.MapFrom(src => src.Salary)));

            EmployeeDTO GuyDto = Mapper.Map<Employee, EmployeeDTO>(Guy);

            Console.WriteLine(GuyDto.FirstName);
            Console.WriteLine(GuyDto.LastName);
            Console.WriteLine(GuyDto.Salary);
        }
    }
}