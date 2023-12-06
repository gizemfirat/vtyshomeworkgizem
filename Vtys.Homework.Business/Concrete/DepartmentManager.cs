using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class DepartmentManager : Manager, IDepartmentService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var departments = Repository.GetList<Department>();
            return new SuccessResult("", departments);
        }
    }
}
