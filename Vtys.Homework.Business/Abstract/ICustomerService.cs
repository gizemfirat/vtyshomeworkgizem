using Vtys.Core.Business.Abstract;
using Vtys.Core.Results;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Abstract
{
    public interface ICustomerService : IService
    {
        IResult GetAll();
        IResult GetById(long id);
        IResult Save(Customer customer);
        IResult DeleteById(long id);
    }
}
