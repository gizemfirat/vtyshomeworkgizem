using Microsoft.Extensions.DependencyInjection;
using Vtys.Core.DataAccess.EntityFramework;
using Vtys.Core.DataAccess;
using Vtys.Homework.Entities.Concrete;
using Vtys.Homework.DataAccess.Concrete.EntityFramework;
using Vtys.Core.Entities;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.DataAccess.Concrete.Npgsql;

namespace Vtys.Homework.DataAccess
{
    public class DataAccessDependencyModule
    {
        private IServiceCollection _services;

        public DataAccessDependencyModule(IServiceCollection services)
        {
            _services = services;
            UseEntityFramework<Employee>();
            UseEntityFramework<User>();
            UseEntityFramework<Machine>();
            UseEntityFramework<Project>();
            UseEntityFramework<Entities.Concrete.Task>();
            UseEntityFramework<Department>();
            UseEntityFramework<TaskSource>();
            UseEntityFramework<ProjectSource>();
            UseEntityFramework<Entities.Concrete.TaskStatus>();
            UseEntityFramework<Page>();
            UseEntityFramework<Role>();
            UseEntityFramework<PageRole>();
            UseEntityFramework<TaskStatusHistory>();
            UseEntityFramework<UserRole>();
            UseEntityFramework<Source>();
            UseEntityFramework<Customer>();
            UseEntityFramework<ProjectStatus>();
            UseEntityFramework<ProjectStatusHistory>();
            UseEntityFramework<ProjectType>();
            UseEntityFramework<TaskType>();

            ConfigureQueries();
        }

        private void UseEntityFramework<TEntity>() where TEntity : class, IEntity, new()
        {
            _services.AddSingleton<IEntityRepository<TEntity>, EfEntityRepositoryBase<TEntity, VtysHomeworkDbContext>>();
        }

        private void ConfigureQueries() 
        {
            _services.AddSingleton<IGetEmployeesQuery, NpgsqlGetEmployeesQuery>();
            _services.AddSingleton<IGetProjectsQuery, NpgsqlGetProjectsQuery>();
            _services.AddSingleton<IGetProjectSourcesQuery, NpgsqlGetProjectSourcesQuery>();
        }
    }
}
