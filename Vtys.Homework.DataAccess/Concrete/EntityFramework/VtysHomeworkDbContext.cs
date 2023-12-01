using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using Vtys.Core.DataAccess;
using Vtys.Core.DependencyManagement;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.DataAccess.Concrete.EntityFramework
{
    public class VtysHomeworkDbContext : DbContext
    {
        public VtysHomeworkDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbConnectionInfo = DependencyResolver.Get<DbConnectionInfo>();
            var connectionString = dbConnectionInfo?.ToNpgsqlString();
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>().UseTptMappingStrategy();
            modelBuilder.Entity<Employee>().UseTptMappingStrategy();
        }

        public DbSet<Source> Sources { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
