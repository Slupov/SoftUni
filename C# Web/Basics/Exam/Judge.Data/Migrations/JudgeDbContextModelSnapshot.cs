﻿// <auto-generated />
using Judge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Judge.Data.Migrations
{
    [DbContext(typeof(JudgeDbContext))]
    partial class JudgeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Judge.Data.Models.Contest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Contests");
                });

            modelBuilder.Entity("Judge.Data.Models.Submission", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ContestId");

                    b.Property<string>("Code");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "ContestId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("ContestId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("Judge.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Judge.Data.Models.Contest", b =>
                {
                    b.HasOne("Judge.Data.Models.User", "User")
                        .WithMany("Contests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Judge.Data.Models.Submission", b =>
                {
                    b.HasOne("Judge.Data.Models.Contest", "Contest")
                        .WithMany("Submissions")
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Judge.Data.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}