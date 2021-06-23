using APPFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APPFinal
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Employees { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        // overrides the OnConfigure Method 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employes.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
