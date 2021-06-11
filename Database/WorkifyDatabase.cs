namespace Workify_Backend.Database
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.IO;

    public class WorkifyDatabase : DbContext
    {
        private static string DatabaseFile { get; } = @".\Workifydb.db";

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.UserTraining> UserTrainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment
                .GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "Workify");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);
            optionsBuilder
            .UseSqlite("Data Source = " + path + ";");
        }
    }
}