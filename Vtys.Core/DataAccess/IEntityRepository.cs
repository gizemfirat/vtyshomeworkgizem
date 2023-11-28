using System.Linq.Expressions;
using Vtys.Core.Entities;

namespace Vtys.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntitiy, new()
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        void Delete(long Id);

        T? Get(Expression<Func<T, bool>>? filter = null);

        List<T> GetList(Expression<Func<T, bool>>? filter = null);
    }
}
