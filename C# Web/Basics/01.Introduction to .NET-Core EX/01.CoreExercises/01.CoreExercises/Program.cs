using System;
using System.Linq;

namespace _01.Student_System
{
    public class Program
    {
        private static readonly StudentSystemContext db = new StudentSystemContext();

        public static void Main()
        {
            Console.WriteLine(
                "Choose subproblem from 1-5: 1 - List Students, 2 - List courses, 3 - courses with more than 5 resources, 4 - active courses by date, 5 - students with data");
            byte option = Convert.ToByte(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListStudents();
                    break;
                case 2:
                    ListCourses();
                    break;
                case 3:
                    ListCoursesWithMoreThan5Resources();
                    break;
                case 4:
                    ListActiveCoursesByDate();
                    break;
                case 5:
                    ListStudentsWithData();
                    break;
                default:
                    Console.WriteLine("Wrong option, choose another");
                    Main();
                    break;
            }
        }

        private static void ListStudents()
        {
            foreach (var stu in db.Students.ToList())
            {
                Console.WriteLine($@"Student: {stu.Name}");
                if (stu.Homeworks.Count == 0)
                {
                    Console.WriteLine("--No Homeworks");
                    continue;
                }
                foreach (var hw in stu.Homeworks.ToList())
                {
                    Console.WriteLine($@"--{hw.ContentType} {hw.Content}");
                }
            }
        }

        private static void ListCourses()
        {
            foreach (var crs in db.Courses.OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate).ToList())
            {
                Console.WriteLine($"Course: {crs.Name}\nDescription: {crs.Description}");
                if (crs.Resources.Count == 0)
                {
                    Console.WriteLine("--NO RESOURCES");
                    Console.WriteLine(new string('+', 100));
                    continue;
                }
                foreach (var rsr in crs.Resources.ToList())
                {
                    Console.WriteLine($"--Resource:");
                    Console.WriteLine($"----Name: {rsr.Name}");
                    Console.WriteLine($"----Url: {rsr.Url}");
                    Console.WriteLine($"----Type: {rsr.ResourceType}");
                }
                Console.WriteLine(new string('+', 100));
            }
        }

        private static void ListCoursesWithMoreThan5Resources()
        {
            var courses =
                db.Courses.Where(c => c.Resources.Count > 5)
                    .OrderByDescending(c => c.Resources.Count)
                    .ThenByDescending(c => c.StartDate);
            if (courses.ToList().Count == 0)
            {
                Console.WriteLine("No such courses");
                return;
            }
            foreach (var crs in courses)
            {
                Console.WriteLine($@"Course: {crs.Name} ResourceCount: {crs.Resources.Count}");
            }
        }

        private static void ListActiveCoursesByDate()
        {
            Console.WriteLine("Enter the date wanted in format dd-mm-yyy: ");
            DateTime dt = Convert.ToDateTime(Console.ReadLine());

            var courses =
                db.Courses.Where(c => c.StartDate < dt && c.EndDate > dt)
                    .OrderByDescending(c => c.Students.Count)
                    .ThenByDescending(c => (c.StartDate - c.EndDate).TotalDays).ToList();

            foreach (var crs in courses)
            {
                Console.WriteLine($"Course: {crs.Name} {crs.StartDate} - {crs.EndDate}");
                Console.WriteLine($"Duration: {(crs.EndDate - crs.StartDate).Days} days");
                Console.WriteLine($"{crs.Students.Count} enrolled.");
                Console.WriteLine(new string('+', 100));
            }
        }

        private static void ListStudentsWithData()
        {
            foreach (
                var stu in
                db.Students.OrderByDescending(s => s.Courses.Sum(c => c.Price))
                    .ThenByDescending(s => s.Courses.Count)
                    .ThenBy(s => s.Name)
                    .ToList())
            {
                Console.WriteLine($"Student: {stu.Name} | Total courses price: ${stu.Courses.Sum(c => c.Price)}");
                Console.WriteLine($"Avg Price: {stu.Courses.Average(c => c.Price)}");
                Console.WriteLine($"Number of Courses: {stu.Courses.Count}");
                Console.WriteLine(new string('+', 100));
            }
        }
    }
}