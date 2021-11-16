using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REST_Practice.DTOs;
using REST_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Practice.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<WeatherForecast>() // Creating Alternative Key
                .ToTable("WeatherForecast")
                .HasAlternateKey(w => w.NewCasterID);

            modelBuilder.Entity<WeatherForecast>() // Setting Properties of Id Column
                .Property(w => w.Id)
                        .IsRequired()
                        .HasColumnName("ForecastId")
                        .HasMaxLength(5)
                        .HasColumnType("int");

            modelBuilder.Entity<Student>() // Creating one-one relationship
                .HasOne<StudentAddress>(s => s.Address)
                .WithOne(ad => ad.Student)
                .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            // Creating many-many relationship

            modelBuilder.Entity<StudentCourse>() // Composite-primary key of middle table
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>() // One-Many relation from student side
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>() // One-Many relation from course side
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

    }
}
