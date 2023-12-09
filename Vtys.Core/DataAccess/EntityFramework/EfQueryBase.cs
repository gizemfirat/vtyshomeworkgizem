using Microsoft.EntityFrameworkCore;

namespace Vtys.Core.DataAccess.EntityFramework
{
    public abstract class EfQueryBase<T, TContext> : IQuery<T> 
        where T : class, new()
        where TContext : DbContext, new()
    {
        public abstract T Run(object? args = null);

        protected object ExecuteQuery(string query) 
        {
            using (var context = new TContext())
            {
                //var result = context.Database.SqlQuery<object>($"{query}").ToList();
                return null;
            }
        }
    }
}
