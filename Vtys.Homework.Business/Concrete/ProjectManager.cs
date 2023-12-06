using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class ProjectManager : Manager, IProjectService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projects = Repository.GetList<Project>();
            return new SuccessResult("", projects);
        }
    }
}
