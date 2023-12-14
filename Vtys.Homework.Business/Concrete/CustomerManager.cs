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
    public class CustomerManager : Manager, ICustomerService
    {
        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var customers = Repository.GetList<Customer>();
            return new SuccessResult("", customers);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id)
        {
            var customers = Repository.Get<Customer>(x => x.Id == id);
            return new SuccessResult("", customers);
        }

        [ExceptionResultAspect]
        public IResult Save(Customer customer)
        {
            customer = customer.Id == 0
                ? Repository.Add(customer)
                : Repository.Update(customer);

            return new SuccessResult("", customer);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id)
        {
            var customer = Repository.Get<Customer>(x => x.Id == id);
            if (customer != null)
            {
                Repository.Delete(customer);
            }
            return new SuccessResult("");
        }
    }
}
