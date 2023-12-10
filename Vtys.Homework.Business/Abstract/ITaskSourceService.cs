using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ITaskSourceService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(TaskSource taskSource);
        IResult DeleteById(long id);
    }
}
