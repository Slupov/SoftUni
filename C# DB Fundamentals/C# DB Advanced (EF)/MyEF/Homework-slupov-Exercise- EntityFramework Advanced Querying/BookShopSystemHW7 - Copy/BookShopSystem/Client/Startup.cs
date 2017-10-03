using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using EntityFramework.Extensions;
using BookShopSystem.Data;
using BookShopSystem.Models.BookShop;
using BookShopSystem.Models.Gringotts;
using BookShopSystem.ViewModels;

namespace BookShopSystem.Client
{
    class Startup
    {
        public static void Main()
        {
            //            BooksTitlesByAgeRestriction();
            //            GoldenBooks();
            //            BooksByPrice();
            //            NotRealeasedBooks();
            //            BookTitlesByCategory();
            //            BooksReleasedBeforeDate();
            //            AuthorsSearch();
            //            BooksSearch();
            //            FindProfit();
            //            MostRecentBooks();
            //            IncreaseBookCopies();
            //            StoredProcedure();
            //            RemoveBooks();
            //            CallAStoredProcedure();
            //            EmployeesMaxSalaries();
            //            DepositSumForOlivanderFamily();
            //            DepositsFilter();
        }

        //EX1
        public static void BooksTitlesByAgeRestriction()
        {
            BookShopContext db = new BookShopContext();
            string input = Console.ReadLine().ToLower();
            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

            var books = db.Books.Where(b => b.AgeRestriction.ToString() == input).Select(b => b.Title).ToList();

            if (books.Count == 0)
            {
                Console.WriteLine("No such books!");
                return;
            }

            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }

        //EX2
        public static void GoldenBooks()
        {
            BookShopContext db = new BookShopContext();

            var books =
                db.Books.Where(b => b.Edition.ToString() == "Gold" && b.Copies < 5000).Select(b => b.Title).ToList();

            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }

        //EX3
        public static void BooksByPrice()
        {
            BookShopContext db = new BookShopContext();

            var books =
                db.Books.Where(b => b.Price < 5 || b.Price > 40)
                    .OrderBy(b => b.Id)
                    .Select(b => new {b.Title, b.Price})
                    .ToList();
            foreach (var b in books)
            {
                Console.WriteLine(b.Title + " - $" + b.Price);
            }
        }

        //EX4
        public static void NotRealeasedBooks()
        {
            BookShopContext db = new BookShopContext();

            int input = int.Parse(Console.ReadLine());

            var books =
                db.Books.Where(b => b.ReleaseDate.Value.Year != input).OrderBy(b => b.Id).Select(b => b.Title).ToList();

            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }

        //EX5
        public static void BookTitlesByCategory()
        {
            BookShopContext db = new BookShopContext();

            string[] input = Console.ReadLine().Split(' ').ToArray();

            var books = db.Categories
                .Where(c => input.Contains(c.Name))
                .SelectMany(c => c.Books.Select(b => new {Id = b.Id, Title = b.Title}))
                .OrderBy(b => b.Id)
                .ToList();

            foreach (var b in books)
            {
                Console.WriteLine(b.Title);
            }
        }

        //EX6
        public static void BooksReleasedBeforeDate()
        {
            BookShopContext db = new BookShopContext();

            var input = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            var books = db.Books.Where(b => b.ReleaseDate < input)
                .Select(b => new
                {
                    b.Title,
                    b.Edition,
                    b.Price
                })
                .ToList();

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title} - {b.Edition} - {b.Price}");
            }
        }

        //EX7
        public static void AuthorsSearch()
        {
            BookShopContext db = new BookShopContext();
            var inputString = Console.ReadLine();

            var resultAuthors = db.Authors
                .Select(a => new {a.FirstName, a.LastName})
                .Where(a => a.FirstName.EndsWith(inputString))
                .ToList();

            foreach (var a in resultAuthors)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName}");
            }
        }

        //EX8
        public static void BooksSearch()
        {
            BookShopContext db = new BookShopContext();

            var inputString = Console.ReadLine();
            var resultBookTitles = db.Books
                .Select(b => b.Title)
                .Where(title => title.Contains(inputString))
                .ToList();

            foreach (var title in resultBookTitles)
            {
                Console.WriteLine(title);
            }
        }

        //EX9
        public static void BookTitlesSearch()
        {
            BookShopContext db = new BookShopContext();

            var inputString = Console.ReadLine();
            var books = db.Books
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    AFirstName = b.Author.FirstName,
                    ALastName = b.Author.LastName
                })
                .Where(b => b.ALastName.StartsWith(inputString))
                .ToList();

            foreach (var book in books.OrderBy(b => b.Id))
            {
                Console.WriteLine(book.Title + "(" + book.AFirstName + " " + book.ALastName + ")");
            }
        }

        //EX10
        public static void CountBooks()
        {
            BookShopContext db = new BookShopContext();

            var targetLen = int.Parse(Console.ReadLine());
            var booksCount = db.Books.Count(b => b.Title.Length > targetLen);
            Console.WriteLine(booksCount);
        }

        //EX11
        private static void TotalBookCopies()
        {
            BookShopContext db = new BookShopContext();

            var authorsTotalNumbers = db.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToList();

            foreach (var a in authorsTotalNumbers)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName} - {a.TotalBookCopies}");
            }
        }

        //EX12
        public static void FindProfit()
        {
            BookShopContext db = new BookShopContext();

            var categoriesWithTotalProfit = db.Categories.OrderByDescending(c => c.Books.Sum(b => b.Price)).ToList();

            foreach (var cat in categoriesWithTotalProfit)
            {
                Console.WriteLine($"{cat.Name} - ${cat.Books.Sum(b => b.Price)}");
            }
        }

        //EX13
        public static void MostRecentBooks()
        {
            BookShopContext db = new BookShopContext();

            var categories = db.Categories.OrderByDescending(c => c.Books.Count()).ThenBy(c => c.Name).ToList();

            foreach (var cat in categories.Select(c => new {c.Name, c.Books.Count}))
            {
                var books = db.Books.Where(b => b.Categories.Select(c => c.Name).Contains(cat.Name))
                    .Select(b => new {b.Title, b.ReleaseDate})
                    .OrderByDescending(b => b.ReleaseDate)
                    .ThenBy(b => b.Title).Take(3);

                Console.WriteLine($"--{cat.Name}: {cat.Count} books");

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title + " (" + book.ReleaseDate.Value.Year + ")");
                }
            }
        }

        //EX14
        public static void IncreaseBookCopies()
        {
            BookShopContext db = new BookShopContext();

            int totalBooksUpdated = db.Books
                .Where(b => b.ReleaseDate > new DateTime(2013, 06, 06))
                .Update(b => new Book {Copies = b.Copies + 44});
            db.SaveChanges();

            int totalCopiesAdded = 44 * totalBooksUpdated;
            Console.WriteLine(totalCopiesAdded);
        }

        //EX15
        public static void RemoveBooks()
        {
            BookShopContext db = new BookShopContext();

            int deleted = db.Books.Where(b => b.Copies < 4200).Delete();
            db.SaveChanges();

            Console.WriteLine($"{deleted} books deleted");
        }

        //EX16
        public static void StoredProcedure()
        {
            BookShopContext db = new BookShopContext();
            string[] names = Console.ReadLine().Split(' ').ToArray();

            SqlParameter firstNameParameter = new SqlParameter("@FirstName", names[0]);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", names[1]);

            var count =
                db.Database.SqlQuery<int>("EXEC dbo.usp_GetBooksCountByAuthorName @FirstName,@LastName",
                    firstNameParameter,
                    lastNameParameter).First();

            Console.WriteLine(count);
        }

        //EX17
        public static void CallAStoredProcedure()
        {
            var db = new SoftuniContext();

            string[] names = Console.ReadLine().Split(' ').ToArray();

            SqlParameter firstNameParameter = new SqlParameter("@FirstName", names[0]);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", names[1]);

            var projects =
                db.Database.SqlQuery<ProjectViewModel>("EXEC usp_FindProjects @FirstName,@LastName", firstNameParameter,
                    lastNameParameter).ToList();

            foreach (var project in projects)
            {
                if (project.Description.Length >= 20)
                {
                    Console.WriteLine(
                        $"{project.Name} - {project.Description.Substring(0, 20)} ..., {project.StartDate}");
                }
                else
                {
                    Console.WriteLine($"{project.Name} - {project.Description}, {project.StartDate}");
                }
            }
        }

        //EX18
        public static void EmployeesMaxSalaries()
        {
            var db = new SoftuniContext();

            var depts =
                db.Departments.Where(
                        d => d.Employees.Max(e => e.Salary) < 30000m || d.Employees.Max(e => e.Salary) > 70000m)
                    .Select(d => new {d.Name, max = d.Employees.Max(e => e.Salary)})
                    .ToList();

            foreach (var d in depts)
            {
                Console.WriteLine($"{d.Name} - {d.max}");
            }
        }

        //EX19
        public static void DepositSumForOlivanderFamily()
        {
            var db = new GringottsContext();

            var depositGroups =
                db.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                    .GroupBy(w => w.DepositGroup, w => w.DepositAmount, (key, g) => new
                    {
                        depositGroup = key,
                        depositAmount = g.Sum()
                    });

            foreach (var dg in depositGroups)
            {
                Console.WriteLine(dg.depositGroup + " - $" + dg.depositAmount);
            }
        }

        //EX20
        public static void DepositsFilter()
        {
            var db = new GringottsContext();

            var depositGroups =
                db.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                    .GroupBy(w => w.DepositGroup, w => w.DepositAmount, (key, g) => new
                    {
                        depositGroup = key,
                        depositAmount = g.Sum()
                    }).Where(dg => dg.depositAmount < 150000).OrderByDescending(dg => dg.depositAmount);

            foreach (var dg in depositGroups)
            {
                Console.WriteLine(dg.depositGroup + " - $" + dg.depositAmount);
            }
        }
    }
}