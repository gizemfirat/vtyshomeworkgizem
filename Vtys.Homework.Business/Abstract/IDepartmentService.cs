using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;

namespace Vtys.Homework.Business.Abstract
{
    public interface IDepartmentService : IService
    {
        IResult GetAll();
    }
}
