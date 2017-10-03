using System.Collections.Generic;
using System.Linq;
using Models.StudentSystem;
//Update-Database -ConfigurationTypeName Configuration

namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.StudentSystemContext context)
        {
            context.Resources.AddOrUpdate(r => r.Name,
                new Resource
                {
                    Name = "Lecture 1",
                    ResourceType = "mp4",
                    Url = "www.youtube.com/mit/citb200",
                },
                new Resource
                {
                    Name = "Lecture 1 text",
                    ResourceType = "doc",
                    Url = "www.documents.com/09saa0f923",

                },
                new Resource
                {
                    Name = "Sorting algorithms",
                    ResourceType = "pdf",
                    Url = "No Url",
                },
                new Resource
                {
                    Name = "How to not get mad while studying",
                    ResourceType = "mp4",
                    Url = "No Url",
                }
            );

            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.Name,
                new Course
                {
                    Name = "Discrete Maths",
                    Description = "The course aims to improve student's knowledge",
                    StartDate = new DateTime(2016, 10, 27),
                    EndDate = new DateTime(2017, 2, 1),
                    Price = 250.99m,
                    Resources =
                    {
                        context.Resources.First(r => r.Name == "Lecture 1" ),
                        context.Resources.First(r => r.Name =="Lecture 1 text")
                    }
                },
                new Course
                {
                    Name = "Programming with C++",
                    Description = "The course aims to improve student's programming abilities",
                    StartDate = new DateTime(2016, 11, 1),
                    EndDate = new DateTime(2017, 2, 15),
                    Price = 100.80m
                },
                new Course
                {
                    Name = "Basic Algorithms",
                    Description = "The course aims to improve student's logic",
                    StartDate = new DateTime(2016, 10, 15),
                    EndDate = new DateTime(2017, 1, 19),
                    Price = 169.55m,

                    Resources =
                    {
                        context.Resources.First(r => r.Name == "Sorting algorithms" ),
                        context.Resources.First(r => r.Name == "How to not get mad while studying" ),
                        
                    }
                }
            );
            context.SaveChanges();

            context.Students.AddOrUpdate(s => s.Name,
                new Student
                {
                    Name = "Andrew Peters",
                    PhoneNumber = "0887235678",
                    RegisteredOn = new DateTime(2014, 10, 2),
                    BirthDay = new DateTime(1996, 12, 4),
                    Courses =
                    {
                        context.Courses.First(c => c.Name == "Discrete Maths"),
                        context.Courses.First(c => c.Name == "Basic Algorithms")
                    }
                },
                new Student
                {
                    Name = "Brice Lambson",
                    PhoneNumber = "0885235611",
                    RegisteredOn = new DateTime(2014, 11, 7),
                    BirthDay = new DateTime(1996, 5, 13),
                    Courses =
                    {
                        context.Courses.First(c => c.Name == "Discrete Maths"),
                        context.Courses.First(c => c.Name == "Basic Algorithms"),
                        context.Courses.First(c => c.Name == "Programming with C++")
                    }
                },
                new Student
                {
                    Name = "Rowan Miller",
                    PhoneNumber = "0885233678",
                    RegisteredOn = new DateTime(2015, 8, 3),
                    BirthDay = new DateTime(1995, 10, 4),
                    Courses =
                    {
                        context.Courses.First(c => c.Name == "Discrete Maths"),
                        context.Courses.First(c => c.Name == "Programming with C++")
                    }
                },
                new Student
                {
                    Name = "James Rollson",
                    PhoneNumber = "0886385676",
                    RegisteredOn = new DateTime(2016, 5, 19),
                    BirthDay = new DateTime(1989, 12, 12),
                    Courses =
                    {
                        context.Courses.First(c => c.Name == "Basic Algorithms"),
                        context.Courses.First(c => c.Name == "Programming with C++")
                    }
                }
            );

            context.SaveChanges();

            context.Homeworks.AddOrUpdate(h => h.SubmissionDate,
                new Homework
                {
                    ContentType = "pdf",
                    SubmissionDate = new DateTime(2017, 3, 9),
                    Student = context.Students.First(s => s.Name == "Andrew Peters")
                },
                new Homework
                {
                    ContentType = "zip",
                    SubmissionDate = new DateTime(2017, 3, 3),
                    Student = context.Students.First(s => s.Name == "Rowan Miller")
                },
                new Homework
                {
                    ContentType = "rar",
                    SubmissionDate = new DateTime(2017, 3, 4),
                    Student = context.Students.First(s => s.Name == "James Rollson")
                }
            );
            context.SaveChanges();

            base.Seed(context);
        }
    }
}