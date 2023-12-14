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
    public class ProjectStatusManager : Manager, IProjectStatusService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projectStatus = Repository.GetList<ProjectStatus>();
            return new SuccessResult("", projectStatus);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var projectStatus = Repository.Get<ProjectStatus>(x => x.Id == id);
            return new SuccessResult("", projectStatus);
        }

        [ExceptionResultAspect]
        public IResult Save(ProjectStatus projectStatus)
        {
            projectStatus = projectStatus.Id == 0
                ? Repository.Add(projectStatus)
                : Repository.Update(projectStatus);

            return new SuccessResult("", projectStatus);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var projectStatus = Repository.Get<ProjectStatus>(x => x.Id == id);
            if (projectStatus != null)
            {
                Repository.Delete(projectStatus);
            }
            return new SuccessResult("");
        }
    }
}
