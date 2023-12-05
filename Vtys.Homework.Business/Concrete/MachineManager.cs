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
    public class MachineManager : Manager, IMachineService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var machines = Repository.GetList<Machine>();
            return new SuccessResult("", machines);
        }
    }
}
