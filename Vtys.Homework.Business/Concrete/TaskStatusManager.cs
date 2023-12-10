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
    public class TaskStatusManager : Manager, ITaskStatusService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var taskStatus = Repository.GetList<Entities.Concrete.TaskStatus>();
            return new SuccessResult("", taskStatus);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var taskSatus = Repository.Get<Entities.Concrete.TaskStatus>(x => x.Id == id);
            return new SuccessResult("", taskSatus);
        }

        [ExceptionResultAspect]
        public IResult Save(Entities.Concrete.TaskStatus taskStatus)
        {
            taskStatus = taskStatus.Id == 0
                ? Repository.Add(taskStatus)
                : Repository.Update(taskStatus);

            return new SuccessResult("", taskStatus);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var taskStatus = Repository.Get<Entities.Concrete.TaskStatus>(x => x.Id == id);
            if (taskStatus != null)
            {
                Repository.Delete(taskStatus);
            }
            return new SuccessResult("Task Status deleted successfully!");
        }
    }
}
