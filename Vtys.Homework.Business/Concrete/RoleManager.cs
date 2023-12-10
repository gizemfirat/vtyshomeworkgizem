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
    public class RoleManager : Manager, IRoleService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var roles = Repository.GetList<Role>();
            return new SuccessResult("", roles);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var role = Repository.Get<Role>(x => x.Id == id);
            return new SuccessResult("", role);
        }

        [ExceptionResultAspect]
        public IResult Save(Role role)
        {
            role = role.Id == 0
                ? Repository.Add(role)
                : Repository.Update(role);

            return new SuccessResult("", role);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var role = Repository.Get<Role>(x => x.Id == id);
            if (role != null)
            {
                Repository.Delete(role);
            }
            return new SuccessResult("Role deleted successfully!");
        }
    }
}
