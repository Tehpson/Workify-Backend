namespace Workify_Backend.Database
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;

    public class Database : DbContext
    {
        static string DatabaseFile { get; set; } = @".\Workifydb.db";

        public DbSet<Models.User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment
                .GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "Workify");
                Directory.CreateDirectory(path);
                path = Path.Combine(path, DatabaseFile);
                optionsBuilder
                .UseSqlite(@"Data Source = " + path + ";");
        }
    }
    
}
