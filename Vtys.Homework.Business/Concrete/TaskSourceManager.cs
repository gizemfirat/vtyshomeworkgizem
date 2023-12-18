using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class TaskSourceManager : Manager, ITaskSourceService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var taskSources = Repository.GetList<TaskSource>();
            var sourceIds = taskSources.Select(x => x.SourceId);
            var taskIds = taskSources.Select(x => x.TaskId);
            var sources = Repository.GetList<Source>(x => sourceIds.Contains(x.Id));
            var tasks = Repository.GetList<Entities.Concrete.Task>(x => taskIds.Contains(x.Id));

            var result = (from ts in taskSources
                          join source in sources on ts.SourceId equals source.Id
                          join task in tasks on ts.TaskId equals task.Id
                          select new
                          {
                              Id = ts.Id,
                              SourceName = source.ToString(),
                              TaskName = task.Name
                          });

            return new SuccessResult("", result);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var taskSource = Repository.Get<TaskSource>(x => x.Id == id);
            return new SuccessResult("", taskSource);
        }

        [ExceptionResultAspect]
        public IResult Save(TaskSource taskSource)
        {
            taskSource = taskSource.Id == 0
                ? Repository.Add(taskSource)
                : Repository.Update(taskSource);

            return new SuccessResult("", taskSource);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var taskSource = Repository.Get<TaskSource>(x => x.Id == id);
            if (taskSource != null)
            {
                Repository.Delete(taskSource);
            }
            return new SuccessResult("Task Source deleted successfully!");
        }
    }
}
