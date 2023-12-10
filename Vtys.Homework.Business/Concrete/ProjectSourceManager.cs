using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class ProjectSourceManager : Manager, IProjectSourceService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projectSource = Repository.GetList<ProjectSource>();
            return new SuccessResult("", projectSource);
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
