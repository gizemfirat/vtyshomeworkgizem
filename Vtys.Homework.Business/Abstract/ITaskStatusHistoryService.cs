using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ITaskStatusHistoryService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(TaskStatusHistory taskStatusHistory);
        IResult DeleteById(long id);
    }
}
