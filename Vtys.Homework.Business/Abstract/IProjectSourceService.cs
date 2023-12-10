using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface IProjectSourceService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(ProjectSource projectSource);
        IResult DeleteById(long id);
    }
}
