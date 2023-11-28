using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vtys.Core.Entities;

namespace Vtys.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return addedEntity.Entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return updatedEntity.Entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            using (var context = new TContext())
            {
                var entity = context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public TEntity? Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var context = new TContext())
            {
                return filter != null
                    ? context.Set<TEntity>().FirstOrDefault(filter)
                    : context.Set<TEntity>().FirstOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
