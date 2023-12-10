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

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var department = Repository.Get<Department>(x => x.Id == id);
            return new SuccessResult("", department);
        }

        [ExceptionResultAspect]
        public IResult Save(Department department)
        {
            department = department.Id == 0
                ? Repository.Add(department)
                : Repository.Update(department);

            return new SuccessResult("", department);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var department = Repository.Get<Department>(x => x.Id == id);
            if (department != null)
            {
                Repository.Delete(department);
            }
            return new SuccessResult("Department deleted successfully!");
        }
    }
}
