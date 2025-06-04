using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using MauiAppYagamiQuizz.Models;

namespace MauiAppYagamiQuizz.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }

        private string _dbPath;

        public AppDbContext()
        {
            var dbName = "quiz.db3";
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, dbName);

            Database.EnsureCreated(); // Cria o banco se não existir
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
