using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface IDepartmentService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(Department department);
        IResult DeleteById(long id);
    }
}
