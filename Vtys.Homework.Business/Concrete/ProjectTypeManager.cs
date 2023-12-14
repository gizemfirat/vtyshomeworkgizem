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
    public class ProjectTypeManager : Manager, IProjectTypeService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projectType = Repository.GetList<ProjectType>();
            return new SuccessResult("", projectType);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var projectType = Repository.Get<ProjectType>(x => x.Id == id);
            return new SuccessResult("", projectType);
        }

        [ExceptionResultAspect]
        public IResult Save(ProjectType projectType)
        {
            projectType = projectType.Id == 0
                ? Repository.Add(projectType)
                : Repository.Update(projectType);

            return new SuccessResult("", projectType);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var projectType = Repository.Get<ProjectType>(x => x.Id == id);
            if (projectType != null)
            {
                Repository.Delete(projectType);
            }
            return new SuccessResult("");
        }
    }
}
