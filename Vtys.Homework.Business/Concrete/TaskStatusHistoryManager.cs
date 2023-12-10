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

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var taskStatusHistory = Repository.Get<TaskStatusHistory>(x => x.Id == id);
            return new SuccessResult("", taskStatusHistory);
        }

        [ExceptionResultAspect]
        public IResult Save(TaskStatusHistory taskStatusHistory)
        {
            taskStatusHistory = taskStatusHistory.Id == 0
                ? Repository.Add(taskStatusHistory)
                : Repository.Update(taskStatusHistory);

            return new SuccessResult("", taskStatusHistory);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var taskStatusHistory = Repository.Get<TaskStatusHistory>(x => x.Id == id);
            if (taskStatusHistory != null)
            {
                Repository.Delete(taskStatusHistory);
            }
            return new SuccessResult("Task Status History deleted successfully!");
        }
    }
}
