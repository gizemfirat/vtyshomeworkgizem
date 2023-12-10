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

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var user = Repository.Get<User>(x => x.Id == id);
            return new SuccessResult("", user);
        }

        [ExceptionResultAspect]
        public IResult Save(User user)
        {
            user = user.Id == 0
                ? Repository.Add(user)
                : Repository.Update(user);

            return new SuccessResult("", user);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var user = Repository.Get<User>(x => x.Id == id);
            if (user != null)
            {
                Repository.Delete(user);
            }
            return new SuccessResult("User deleted successfully!");
        }
    }
}
