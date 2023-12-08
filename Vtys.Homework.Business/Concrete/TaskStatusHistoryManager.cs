using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class TaskStatusHistoryManager : Manager, ITaskStatusHistoryService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var taskStatusHistories = Repository.GetList<TaskStatusHistory>();
            return new SuccessResult("", taskStatusHistories);
        }
    }
}
