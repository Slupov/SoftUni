using Models.Photography;
using Models.StudentSystem;

namespace DataPhotography.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.PhotographyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.PhotographyContext context)
        {
            context.Photographers.AddOrUpdate(p => p.Username,
                new Photographer
                {
                    Username = "Snimcho",
                    Password = "123snimam",
                    Email = "snimcho@abv.bg",
                    BirthDate = new DateTime(2002, 10, 21),
                    RegisterDate = new DateTime(2017, 1, 30)
                },
                new Photographer
                {
                    Username = "Iliyanchoo",
                    Password = "zyzz321@",
                    Email = "ilio@gmail.com",
                    BirthDate = new DateTime(1996, 8, 15),
                    RegisterDate = new DateTime(2016, 11, 20)
                },
                new Photographer
                {
                    Username = "fotosvyat",
                    Password = "f2.5ISO100",
                    Email = "photoworld@gmail.com",
                    BirthDate = new DateTime(2005, 4, 22),
                    RegisterDate = new DateTime(2015, 6, 3)
                }
            );
            context.SaveChanges();

            context.Albums.AddOrUpdate(a => a.Name,
                new Album
                {
                    Name = "Summer 2016",
                    BackgroundColor = "Cyan",
                    IsPublic = false,
                    Owners =
                    {
                        context.Photographers.First(p => p.Username == "Snimcho")
                    },
                    Pictures =
                    {
                        new Picture
                        {
                            Title = "DSC_1000",
                            Caption = "Blue sea",
                            Path = @"D:\Gallery\Summer2k16\DSC_1000",
                        },
                        new Picture
                        {
                            Title = "DSC_1001",
                            Caption = "Beach Babes",
                            Path = @"D:\Gallery\Summer2k16\DSC_1001",
                        },
                        new Picture
                        {
                            Title = "DSC_1000",
                            Caption = "Tsatsa and french fries",
                            Path = @"D:\Gallery\Summer2k16\DSC_1002",
                        }
                    }
                },
                new Album
                {
                    Name = "Borovets-December-2k16",
                    BackgroundColor = "White",
                    IsPublic = true,
                    Owners =
                    {
                        context.Photographers.First(p => p.Username == "Iliyanchoo"),
                        context.Photographers.First(p => p.Username == "fotosvyat")
                    },
                    Pictures =
                    {
                        new Picture
                        {
                            Title = "DSC_2300",
                            Caption = "Blue sea",
                            Path = @"D:\Iliyan\Gallery\Borovets\DSC_2300",
                        },
                        new Picture
                        {
                            Title = "DSC_2301",
                            Caption = "Beach Babes",
                            Path = @"D:\Iliyan\Gallery\Borovets\DSC_2301",
                        },
                        new Picture
                        {
                            Title = "DSC_2315",
                            Caption = "Tsatsa and french fries",
                            Path = @"D:\Iliyan\Gallery\Borovets\DSC_2315",
                        }
                    }
                }
            );
            context.SaveChanges();
        }
    }
}