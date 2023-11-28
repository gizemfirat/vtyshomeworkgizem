using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.DataAccess;
using Vtys.Core.DependencyManagement;
using Vtys.Core.Entities;

namespace Vtys.Core.Business.Concrete
{
    public class Repository 
    {
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            return service?.Add(entity);
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            return service?.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            service.Delete(entity);
        }

        public void Delete<TEntity>(long id) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            service?.Delete(id);
        }

        public TEntity? Get<TEntity>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            return service?.Get(filter);
        }

        public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            return service?.GetList(filter);
        }

        public bool Any<TEntity>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : class, IEntity, new()
        {
            var service = DependencyResolver.Get<IEntityRepository<TEntity>>();
            return service?.GetList(filter)?.Count() > 0;
        }
    }
}
