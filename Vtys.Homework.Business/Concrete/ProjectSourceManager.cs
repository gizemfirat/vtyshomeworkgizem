using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class ProjectSourceManager : Manager, IProjectSourceService
    {

        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projectSources = Repository.GetList<ProjectSource>();
            var sourceIds = projectSources.Select(x => x.SourceId);
            var projectIds = projectSources.Select(x => x.ProjectId);
            var sources = Repository.GetList<Source>(x => sourceIds.Contains(x.Id));
            var projects = Repository.GetList<Project>(x => projectIds.Contains(x.Id));

            var result = (from ps in projectSources
                          join source in sources on ps.SourceId equals source.Id
                          join project in projects on ps.ProjectId equals project.Id
                          select new 
                          {
                              Id = ps.Id,
                              SourceName = source.ToString(),
                              ProjectName = project.Name
                          });
                        
            return new SuccessResult("", result);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var projectSource = Repository.Get<ProjectSource>(x => x.Id == id);
            return new SuccessResult("", projectSource);
        }

        [ExceptionResultAspect]
        public IResult Save(ProjectSource projectSource)
        {
            projectSource = projectSource.Id == 0
                ? Repository.Add(projectSource)
                : Repository.Update(projectSource);

            return new SuccessResult("", projectSource);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var projectSource = Repository.Get<ProjectSource>(x => x.Id == id);
            if (projectSource != null)
            {
                Repository.Delete(projectSource);
            }
            return new SuccessResult("Project Source deleted successfully!");
        }
    }
}
