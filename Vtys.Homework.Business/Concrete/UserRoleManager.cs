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
    public class UserRoleManager : Manager, IUserRoleService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var userRoles = Repository.GetList<UserRole>();
            return new SuccessResult("", userRoles);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var userRole = Repository.Get<UserRole>(x => x.Id == id);
            return new SuccessResult("", userRole);
        }

        [ExceptionResultAspect]
        public IResult Save(UserRole userRole)
        {
            userRole = userRole.Id == 0
                ? Repository.Add(userRole)
                : Repository.Update(userRole);

            return new SuccessResult("", userRole);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var userRole = Repository.Get<UserRole>(x => x.Id == id);
            if (userRole != null)
            {
                Repository.Delete(userRole);
            }
            return new SuccessResult("User Role deleted successfully!");
        }
    }
}
