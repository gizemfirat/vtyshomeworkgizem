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

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var project = Repository.Get<Project>(x => x.Id == id);
            return new SuccessResult("", project);
        }

        [ExceptionResultAspect]
        public IResult Save(Project project)
        {
            project = project.Id == 0
                ? Repository.Add(project)
                : Repository.Update(project);

            return new SuccessResult("", project);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var project = Repository.Get<Project>(x => x.Id == id);
            if (project != null)
            {
                Repository.Delete(project);
            }
            return new SuccessResult("Project deleted successfully!");
        }
    }
}
