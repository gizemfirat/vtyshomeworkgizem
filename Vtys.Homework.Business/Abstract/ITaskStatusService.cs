using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ITaskStatusService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(Entities.Concrete.TaskStatus taskStatus);
        IResult DeleteById(long id);
    }
}
