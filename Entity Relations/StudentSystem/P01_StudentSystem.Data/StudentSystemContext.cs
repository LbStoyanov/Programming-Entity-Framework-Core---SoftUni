using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

// ReSharper disable All

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //Here we configurate the DBContext class
        //FluentAPI
        //Config
        //EF Core

        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options)
        :base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(sc => new {sc.StudentId, sc.CourseId});

            });
        }
    }
}
