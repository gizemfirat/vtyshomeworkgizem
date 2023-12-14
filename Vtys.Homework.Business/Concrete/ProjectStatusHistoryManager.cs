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
    public class ProjectStatusHistoryManager : Manager, IProjectStatusHistoryService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var projectStatusHistories = Repository.GetList<ProjectStatusHistory>();
            return new SuccessResult("", projectStatusHistories);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var projectStatusHistory = Repository.Get<ProjectStatusHistory>(x => x.Id == id);
            return new SuccessResult("", projectStatusHistory);
        }

        [ExceptionResultAspect]
        public IResult Save(ProjectStatusHistory projectStatusHistory)
        {
            projectStatusHistory = projectStatusHistory.Id == 0
                ? Repository.Add(projectStatusHistory)
                : Repository.Update(projectStatusHistory);

            return new SuccessResult("", projectStatusHistory);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var projectStatusHistory = Repository.Get<ProjectStatusHistory>(x => x.Id == id);
            if (projectStatusHistory != null)
            {
                Repository.Delete(projectStatusHistory);
            }
            return new SuccessResult("");
        }
    }
}
