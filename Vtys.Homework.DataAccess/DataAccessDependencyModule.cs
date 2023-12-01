using Microsoft.Extensions.DependencyInjection;
using Vtys.Core.DataAccess.EntityFramework;
using Vtys.Core.DataAccess;
using Vtys.Homework.Entities.Concrete;
using Vtys.Homework.DataAccess.Concrete.EntityFramework;
using Vtys.Core.Entities;
using Vtys.Homework.DataAccess.Concrete.Mock;

namespace Vtys.Homework.DataAccess
{
    public class DataAccessDependencyModule
    {
        private IServiceCollection _services;

        public DataAccessDependencyModule(IServiceCollection services)
        {
            _services = services;
            UseEntityFramework<Employee>();
           // _services.AddSingleton<IEntityRepository<Employee>, MockEmployeeDal>();
        }

        private void UseEntityFramework<TEntity>() where TEntity : class, IEntity, new()
        {
            _services.AddSingleton<IEntityRepository<TEntity>, EfEntityRepositoryBase<TEntity, VtysHomeworkDbContext>>();
        }
    }
}
