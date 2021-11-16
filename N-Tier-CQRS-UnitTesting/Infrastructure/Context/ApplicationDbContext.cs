using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Infrastructure.Context
{
    public class CommandContext : DbContext, ICommandQueryDbSets
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
          => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    public class QueryContext : DbContext, ICommandQueryDbSets
    {
        public QueryContext(DbContextOptions<QueryContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Company { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
    interface ICommandQueryDbSets
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
