using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class UserManager : Manager, IUserService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var users = Repository.GetList<User>();
            return new SuccessResult("", users);
        }
    }
}
