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
    public class TaskTypeManager : Manager, ITaskTypeService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var taskType = Repository.GetList<TaskType>();
            return new SuccessResult("", taskType);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var taskType = Repository.Get<TaskType>(x => x.Id == id);
            return new SuccessResult("", taskType);
        }

        [ExceptionResultAspect]
        public IResult Save(TaskType taskType)
        {
            taskType = taskType.Id == 0
                ? Repository.Add(taskType)
                : Repository.Update(taskType);

            return new SuccessResult("", taskType);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var taskType = Repository.Get<TaskType>(x => x.Id == id);
            if (taskType != null)
            {
                Repository.Delete(taskType);
            }
            return new SuccessResult("");
        }
    }
}
