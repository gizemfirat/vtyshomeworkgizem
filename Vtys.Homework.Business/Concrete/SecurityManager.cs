using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Business.Models;
using Vtys.Homework.Business.ValidationRules;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class SecurityManager : Manager, ISecurityService
    {
        [ExceptionResultAspect]
        [ValidationAspect(typeof(RegisterModelValidator))]
        public IResult Register(RegisterModel model)
        {
            var user = Repository.Add(new User()
            {
                Name = model.Name,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                Surname = model.Surname,
            });

            return new SuccessResult("", user);
        }
    }
}
