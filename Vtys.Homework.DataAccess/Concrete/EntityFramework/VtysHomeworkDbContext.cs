using Microsoft.EntityFrameworkCore;
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

        public DbSet<User> Users { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Entities.Concrete.Task> Tasks { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<TaskSource> TaskSources { get; set; }

        public DbSet<ProjectSource> ProjectSources { get; set; }

        public DbSet<Entities.Concrete.TaskStatus> TaskStatuses { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<PageRole> PageRoles { get; set; }

        public DbSet<TaskStatusHistory> TaskStatusHistories { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<ProjectStatusHistory> ProjectStatusHistories { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }


    }
}
