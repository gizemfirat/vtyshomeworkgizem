using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Business.Models;

namespace Vtys.Homework.Business.Abstract
{
    public interface ISecurityService : IService
    {
        IResult Register(RegisterModel model);
    }
}
