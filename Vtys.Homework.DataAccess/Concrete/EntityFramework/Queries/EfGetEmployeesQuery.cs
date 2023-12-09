using Vtys.Core.DataAccess.EntityFramework;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.DataAccess.Concrete.EntityFramework.Queries
{
    public class EfGetEmployeesQuery : EfQueryBase<List<Employee>, VtysHomeworkDbContext>, IGetEmployeesQuery
    {
        public override List<Employee> Run(object? args = null)
        {
            var result = ExecuteQuery("select * from \"Employees\"");
            return result as List<Employee>;
        }
    }
}
