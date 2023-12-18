using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;
using Task = Vtys.Homework.Entities.Concrete.Task;
using TaskStatus = Vtys.Homework.Entities.Concrete.TaskStatus;

namespace Vtys.Homework.Business.Concrete
{
    public class TaskStatusHistoryManager : Manager, ITaskStatusHistoryService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var taskStatusHistories = Repository.GetList<TaskStatusHistory>();
            var taskIds = taskStatusHistories.Select(x => x.TaskId);
            var taskStatusIds = taskStatusHistories.Select(x => x.StatusId);
            var tasks = Repository.GetList<Task>(x => taskIds.Contains(x.Id));
            var taskStatuses = Repository.GetList<TaskStatus>(x => taskStatusIds.Contains(x.Id));

            var result = (from tsh in taskStatusHistories
                          join task in tasks on tsh.TaskId equals task.Id
                          join taskStatus in taskStatuses on tsh.StatusId equals taskStatus.Id
                          select new
                          {
                              Id = tsh.Id,
                              TaskName = task.Name,
                              TaskStatusName = taskStatus.Name
                          });

            return new SuccessResult("", result);

            //var taskStatusHistories = Repository.GetList<TaskStatusHistory>();
            //return new SuccessResult("", taskStatusHistories);
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
