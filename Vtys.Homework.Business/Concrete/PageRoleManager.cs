using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class PageRoleManager : Manager, IPageRoleService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var pageRoles = Repository.GetList<PageRole>();
            return new SuccessResult("", pageRoles);
        }
    }
}
