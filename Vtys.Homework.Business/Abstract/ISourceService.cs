using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ISourceService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(Source source);
        IResult DeleteById(long id);
    }
}
