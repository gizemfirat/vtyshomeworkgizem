using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class PageManager : Manager, IPageService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var pages = Repository.GetList<Page>();
            return new SuccessResult("", pages);
        }
    }
}
