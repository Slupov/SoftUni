using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _02.Social_Network.Data;
using _02.Social_Network.Models;

namespace _02.Social_Network
{
    public class Program
    {
        private static readonly SocialNetworkContext db = new SocialNetworkContext();

        public static void Main()
        {
            db.Database.EnsureCreated();
            TagProblem();
            SharedAlbumsProblem();
        }

        private static void SharedAlbumsProblem()
        {
            //todo1
//            var usersWithSharedAlbums = db.Photographers.Select(u => new
//            {
//                name = u.Username,
//                albums = u.Albums.Where(a => a.Album.Owners.Count > 1).ToList(),
//                friends = u.
//            })
//            .Where(u => u.albums.Count > 1);
//
//            foreach (var u in usersWithSharedAlbums)
//            {
//                Console.WriteLine($"-{u.name}");
//            }

            //problem 2
            Console.WriteLine();
            Console.WriteLine("Listing 2nd problem");

            var sharedAlbums = db.Albums.Select(u => new
                {
                    name = u.Name,
                    publicity = u.IsPublic,
                    numberOfPpl = u.Owners.Count
                })
                .Where(u => u.numberOfPpl > 2)
                .OrderByDescending(u => u.numberOfPpl)
                .ThenBy(u => u.name);

            foreach (var album in sharedAlbums)
            {
                Console.WriteLine($"@{album.name}: {album.numberOfPpl} people, IsPublic: {album.publicity}");
            }

            //problem 3
            Console.WriteLine();
            Console.WriteLine("Listing 3rd problem");
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            var photographer = db.Photographers
                .FirstOrDefault(p => p.Username == username);

            if (photographer != null)
            {
                var sharedAlbums2 = db.Albums
                    .Where(a => a.Owners.Any(o => o.Photographer.Username == photographer.Username))
                    .Select(a => new
                    {
                        name = a.Name,
                        pictureCount = a.Pictures.Count
                    })
                    .OrderByDescending(a => a.pictureCount)
                    .ThenBy(a => a.name);

                foreach (var album in sharedAlbums2)
                {
                    Console.WriteLine($"@ {album.name} with {album.pictureCount} pictures");
                }
            }
        }

        private static void TagProblem()
        {
            Console.WriteLine("TAGS SOLUTION:");
            Console.Write("Enter your hashtag: ");
            string input = Console.ReadLine();

            input = TagTransformer.Transform(input);
            db.Tags.Add(new Tag
            {
                Name = input
            });

            Console.WriteLine("Transformed: " + input);
            try
            {
                db.SaveChanges();
                Console.WriteLine($"Tag {input} was added to the database!");
            }
            catch (DbUpdateException ex)
            {
                Console.Write("DbEntityValidationException: ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}