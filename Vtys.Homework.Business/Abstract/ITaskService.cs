using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ITaskService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(TaskSavingModel model);
        IResult DeleteById(long id);
        IResult GetAllSources();
    }
}
