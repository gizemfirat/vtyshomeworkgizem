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

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var machine = Repository.Get<Machine>(x => x.Id == id);
            return new SuccessResult("", machine);
        }

        [ExceptionResultAspect]
        public IResult Save(Machine machine)
        {
            machine = machine.Id == 0
                ? Repository.Add(machine)
                : Repository.Update(machine);

            return new SuccessResult("", machine);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var machine = Repository.Get<Machine>(x => x.Id == id);
            if (machine != null)
            {
                Repository.Delete(machine);
            }
            return new SuccessResult("Machine deleted successfully!");
        }
    }
}
