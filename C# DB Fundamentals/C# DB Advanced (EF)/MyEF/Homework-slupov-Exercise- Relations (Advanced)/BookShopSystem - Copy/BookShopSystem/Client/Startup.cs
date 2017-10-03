using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;

namespace BookShopSystem.Client
{
    class Startup
    {
        public static void Main()
        {
            var db = new BookShopContext();

            db.Database.Initialize(true);
            var bookCount = db.Books.Count();
            Exercise6(db);

        }

        private static void Exercise6(BookShopContext context)
        {
            var books = context.Books.Take(3).ToList();

            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            books = context.Books.Take(3).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"--{book.Title}");
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }

    }
}