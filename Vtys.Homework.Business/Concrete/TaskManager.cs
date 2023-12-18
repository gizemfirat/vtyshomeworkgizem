using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;
using TaskStatus = Vtys.Homework.Entities.Concrete.TaskStatus;

namespace Vtys.Homework.Business.Concrete
{
    public class TaskManager : Manager, ITaskService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var tasks = Repository.GetList<Entities.Concrete.Task>();
            return new SuccessResult("", tasks);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var task = Repository.Get<Entities.Concrete.Task>(x => x.Id == id);
            var sourceIds = Repository.GetList<TaskSource>(x => x.TaskId == task.Id).Select(x => x.SourceId);
            var result = new { Task = task, SourceIds = sourceIds };
            return new SuccessResult("", result);
        }

        [ExceptionResultAspect]
        [TransactionScopeAspect]
        public IResult Save(TaskSavingModel model)
        {
            var task = model.Task.Id == 0
                ? Repository.Add(model.Task)
                : Repository.Update(model.Task);

            var taskSources = Repository.GetList<TaskSource>(x => x.TaskId == task.Id);
            var deleteds = taskSources.Where(x => !model.SourceIds.Contains(x.SourceId));
            var addeds = model.SourceIds.Where(x => !taskSources.Any(y => y.SourceId == x));

            foreach (var source in deleteds)
            {
                Repository.Delete(source);
            }
            foreach (var sourceId in addeds)
            {
                Repository.Add(new TaskSource()
                {
                    TaskId = task.Id,
                    SourceId = sourceId,

                });
            }

            return new SuccessResult("", task);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var task = Repository.Get<Entities.Concrete.Task>(x => x.Id == id);
            if (task != null)
            {
                Repository.Delete(task);
            }
            return new SuccessResult("Task deleted successfully!");
        }

        [ExceptionResultAspect]
        public IResult GetAllSources()
        {
            var taskSources = Repository.GetList<TaskSource>();
            var sourceIds = taskSources.Select(x => x.SourceId);
            var sources = Repository.GetList<Source>(x => sourceIds.Contains(x.Id));
            return new SuccessResult("", sources);
        }

        [ExceptionResultAspect]
        public IResult GetHistory(long taskId)
        {
            var taskStatusHistories = Repository.GetList<TaskStatusHistory>(x => x.TaskId == taskId);
            var statusIds = taskStatusHistories.Select(x => x.StatusId);
            var taskStatuses = Repository.GetList<TaskStatus>(x => statusIds.Contains(x.Id));
            var result = (from tsh in taskStatusHistories
                          join ts in taskStatuses on tsh.StatusId equals ts.Id
                          orderby tsh.InsertedDate descending
                          select new
                          {
                              Name = ts.Name,
                              Date = tsh.InsertedDate
                          });

            return new SuccessResult("", result);
        }
    }
}
