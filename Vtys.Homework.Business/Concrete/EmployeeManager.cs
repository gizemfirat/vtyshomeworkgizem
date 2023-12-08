using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class EmployeeManager : Manager, IEmployeeService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var employees = Repository.GetList<Employee>();
            return new SuccessResult("", employees);
        }
        [ExceptionResultAspect]
        public void Add(Employee employee)
        {
            Repository.Add<Employee>(employee);
        }
    }
}
