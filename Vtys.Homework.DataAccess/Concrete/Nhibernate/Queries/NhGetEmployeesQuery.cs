using Vtys.Core.DataAccess.Nhibernate;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.DataAccess.Concrete.Nhibernate.Queries
{
    public class NhGetEmployeesQuery : NhQueryBase<List<Employee>>, IGetEmployeesQuery
    {
        public override List<Employee> Run(object? args = null)
        {
            //var result = ExecuteQuery("select id from members");
            //return result as List<Employee>;
            return new List<Employee> { new Employee() };
        }
    }
}
