using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;
using Group = TestingSystem.DAL.Models.Group;

namespace TestingSystem.DAL
{
    public class TestingSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Models.Group> Groups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Teachers)
                .WithMany(t => t.Groups)
                .UsingEntity("TeacherGroup");
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Groups)
                .WithMany(g => g.Teachers)
                .UsingEntity("TeacherGroup");

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Tests)
                .WithMany(t => t.Groups)
                .UsingEntity("GroupTest");
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Groups)
                .WithMany(g => g.Tests)
                .UsingEntity("GroupTest");
        }
    }
}
