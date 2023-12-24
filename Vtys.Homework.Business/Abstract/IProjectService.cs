using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface IProjectService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(ProjectSavingModel model);
        IResult DeleteById(long id);

        IResult GetAllWithDetail();
        IResult GetSources(long projectId);

        IResult GetAllSources();

        IResult GetHistory(long projectId);
    }
}
