using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Hamza",
                    Email = "hamza@gmail.com",
                    Department = Dept.Finance
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Ali",
                    Email = "ali@gmail.com",
                    Department = Dept.IT
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Danish",
                    Email = "danish@gmail.com",
                    Department = Dept.Finance
                }
            );
        }
    }
}
