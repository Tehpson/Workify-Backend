﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workify_Backend.Database;

namespace Workify_Backend.Migrations
{
    [DbContext(typeof(WorkifyDatabase))]
    partial class WorkifyDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Workify_Backend.Models.User", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PublicProfile")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Workify_Backend.Models.UserTraining", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgPath")
                        .HasColumnType("TEXT");

                    b.Property<int>("Layout")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<ulong?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTrainings");
                });

            modelBuilder.Entity("Workify_Backend.Models.UserTraining", b =>
                {
                    b.HasOne("Workify_Backend.Models.User", null)
                        .WithMany("trainings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Workify_Backend.Models.User", b =>
                {
                    b.Navigation("trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
