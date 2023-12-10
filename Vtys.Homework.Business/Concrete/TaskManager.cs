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
        public IResult Save(Entities.Concrete.Task task)
        {
            task = task.Id == 0
                ? Repository.Add(task)
                : Repository.Update(task);

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
    }
}
