using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Section2.Hospital;

namespace Section2
{
    class Startup
    {
        static void Main(string[] args)
        {
            GringottsDbContext gringottsDbContext = new GringottsDbContext();
            UsersContext usersDbContext = new UsersContext();
            HospitalDbContext hospitalDbDbContext = new HospitalDbContext();
//            InsertWizzards(gringottsDbContext);
//            InsertUsers(usersDbContext);
//            CreateHospitalDb(hospitalDbDbContext);
//            ModifyHospitalDb(hospitalDbDbContext);
//            GetUsersByEmailProvider(usersDbContext);
            RemoveInactiveUsers(usersDbContext);
        }

        //Exercise 7
        static void InsertWizzards(GringottsDbContext db)
        {
            //some hardcoded data (no sql file given for this)
            var data = new List<WizardDeposit>()
            {
                new WizardDeposit
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    Age = 150,
                    MagicWandCreator = "Antioch Peverell",
                    MagicWandSize = 15,
                    DepositStartDate = new DateTime(2016, 10, 20),
                    DepositExpirationDate = new DateTime(2020, 10, 20),
                    DepositAmount = 20000.24m,
                    DepositCharge = 0.2m,
                    IsDepositExpired = false
                },
                new WizardDeposit
                {
                    FirstName = "Harry",
                    LastName = "Poten",
                    Age = 16,
                    MagicWandCreator = "Mincho Praznikov",
                    MagicWandSize = 9,
                    DepositStartDate = new DateTime(2014, 9, 15),
                    DepositExpirationDate = new DateTime(2018, 9, 15),
                    DepositAmount = 15325.25m,
                    DepositCharge = 0.5m,
                    IsDepositExpired = false
                },
                new WizardDeposit
                {
                    FirstName = "Emma",
                    LastName = "Watson",
                    Age = 150,
                    MagicWandCreator = "Hagrid Debeliya",
                    MagicWandSize = 10,
                    DepositStartDate = new DateTime(2014, 08, 25),
                    DepositExpirationDate = new DateTime(2018, 08, 25),
                    DepositAmount = 7825.10m,
                    DepositCharge = 0.5m,
                    IsDepositExpired = false
                },
            };

            db.WizzardDeposits.AddRange(data);

            try
            {
                db.SaveChanges();
                Console.WriteLine("Entries successfully saved!");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var validationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(validationError.ErrorMessage);
                    }
                }
            }
        }

        //Exercise 8
        static void InsertUsers(UsersContext db)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=UsersDB;Integrated Security = true;";

            string query = File.ReadAllText(@"..\..\Users\UsersData.sql");

            connection.Open();
            using (connection)
            {
                SqlCommand insertUsers = new SqlCommand(query, connection);
                insertUsers.ExecuteNonQuery();

                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Entries successfully saved!");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in dbEntityValidationResult.ValidationErrors)
                        {
                            Console.WriteLine(validationError.ErrorMessage);
                        }
                    }
                }
            }
            connection.Close();
        }

        //PM> Enable-Migrations -ProjectName Section2 -StartUpProjectName Section2 -Verbose

        //Exercise 9
        static void CreateHospitalDb(HospitalDbContext db)
        {
            db.Patients.Add(new Patient
            {
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "pepi44@gmail.com",
                Address = "Sofia Tintyava 15",
                Birthdate = new DateTime(1988, 9, 15),
                IsInsured = true
            });

            try
            {
                db.SaveChanges();
                Console.WriteLine("Entities successfully saved!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        static void ModifyHospitalDb(HospitalDbContext db)
        {
            db.Doctors.Add(new Doctor
            {
                Name = "Joro Ardashev",
                Speciality = "GP",
                Visitations = new HashSet<Visitation>()
            });

            db.SaveChanges();
        }

        //Exercise 11
        static void GetUsersByEmailProvider(UsersContext db)
        {
            string provider = Console.ReadLine();
            var users = db.Users.Where(u => u.Email.EndsWith(provider)).Select(u => new
                {
                    Username = u.Username,
                    Email = u.Email
                })
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine(user.Username + " " + user.Email);
            }
        }

        static void RemoveInactiveUsers(UsersContext db)
        {
            Console.WriteLine("Enter a date separated with format DD MM YYYY");
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            DateTime targetDate = new DateTime(input[2], input[1], input[0]);
            var toDelete = db.Users
                .Where(u => u.LastTimeLoggedIn < targetDate)
                .ToList();

            int usersDeleted = 0;
            toDelete.ForEach(u =>
            {
                u.IsDeleted = true;
                usersDeleted++;
            });

            try
            {
                db.SaveChanges();
                Console.WriteLine($"{usersDeleted} users have been successfully removed");
            }
            catch (DbEntityValidationException ex)
            {
            //There are some invalid entries in the insert query given in the assignment
            //For example username "Hu" doesnt match the 4 to 30 character username validation !
                foreach (var dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var validationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(validationError.ErrorMessage);
                    }
                }
            }
            
        }
    }
}