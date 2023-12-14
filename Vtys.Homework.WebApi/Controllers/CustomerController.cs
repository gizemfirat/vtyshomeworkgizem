using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("api/customers")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _customerService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/customers/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _customerService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/customers")]
        public IActionResult Save([FromBody] Customer customer)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _customerService.Save(customer).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/customers/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _customerService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
