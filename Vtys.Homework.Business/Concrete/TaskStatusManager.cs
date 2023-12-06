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
    }
}
