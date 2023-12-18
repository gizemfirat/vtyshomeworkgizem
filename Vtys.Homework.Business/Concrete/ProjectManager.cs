using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Business.Constants;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.ComplexTypes;
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
            var sourceIds = Repository.GetList<ProjectSource>(x => x.ProjectId == project.Id).Select(x => x.SourceId);
            var result = new { Project = project, SourceIds = sourceIds };
            return new SuccessResult("", result);
        }

        [ExceptionResultAspect]
        [TransactionScopeAspect]
        public IResult Save(ProjectSavingModel model)
        {
            var project = model.Project.Id == 0
                ? Repository.Add(model.Project)
                : Repository.Update(model.Project);

            var projectSources = Repository.GetList<ProjectSource>(x => x.ProjectId == project.Id);
            var deleteds = projectSources.Where(x => !model.SourceIds.Contains(x.SourceId));
            var addeds = model.SourceIds.Where(x => !projectSources.Any(y => y.SourceId == x));

            foreach (var source in deleteds) 
            {
                Repository.Delete(source);
            }
            foreach (var sourceId in addeds)
            {
                Repository.Add(new ProjectSource() 
                {
                    ProjectId = project.Id,
                    SourceId = sourceId,
                });
            }

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

        [ExceptionResultAspect]
        public IResult GetHistory(long projectId)
        {
            var projectStatusHistories = Repository.GetList<ProjectStatusHistory>(x => x.ProjectId == projectId);
            var statusIds = projectStatusHistories.Select(x => x.StatusId);
            var projectStatuses = Repository.GetList<ProjectStatus>(x => statusIds.Contains(x.Id));
            var result = (from psh in projectStatusHistories
                          join ps in projectStatuses on psh.StatusId equals ps.Id
                          orderby psh.InsertedDate descending
                          select new
                          {
                              Name = ps.Name,
                              Date = psh.InsertedDate
                          });

            return new SuccessResult("", result);
        }
    }
}
