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
            return new SuccessResult("", task);
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
    }
}
