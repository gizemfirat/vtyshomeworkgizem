using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/roles")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _roleService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }


        [HttpGet]
        [Route("api/roles/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _roleService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/roles")]
        public IActionResult Save([FromBody] Role role)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _roleService.Save(role).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/roles/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _roleService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
