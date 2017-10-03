using System;
using System.Data.Entity.Validation;
using Data;
using Models.Photography;

namespace Client.Exercise8
{
    public class Solution
    {
        private static readonly PhotographyContext db = new PhotographyContext();

        public static void Start()
        {
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
            catch (DbEntityValidationException ex)
            {
                Console.Write("DbEntityValidationException: ");
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var validationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.Write(validationError.ErrorMessage);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}