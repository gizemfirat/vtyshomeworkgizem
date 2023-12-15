using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Business.Constants;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class ProjectManager : Manager, IProjectService
    {
        private readonly IGetProjectsQuery _getProjectsQuery;
        public ProjectManager(IGetProjectsQuery getProjectsQuery)
        {
            _getProjectsQuery = getProjectsQuery;
        }

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
            return new SuccessResult(Messages.SUCCESSFULLY_DELETED);
        }

        [ExceptionResultAspect]
        public IResult GetAllWithDetail()
        {
            var projects = _getProjectsQuery.Run();
            return new SuccessResult("", projects);
        }

        [ExceptionResultAspect]
        public IResult GetSources(long projectId)
        {
            var projectSources = Repository.GetList<ProjectSource>(x => x.ProjectId == projectId);
            var sourceIds = projectSources.Select(x => x.SourceId);
            var sources = Repository.GetList<Source>(x => sourceIds.Contains(x.Id));
            return new SuccessResult("", sources);
        }

        [ExceptionResultAspect]
        public IResult GetAllSources()
        {
            var projectSources = Repository.GetList<ProjectSource>();
            var sourceIds = projectSources.Select(x => x.SourceId);
            var sources = Repository.GetList<Source>(x => sourceIds.Contains(x.Id));
            return new SuccessResult("", sources);
        }
    }
}
