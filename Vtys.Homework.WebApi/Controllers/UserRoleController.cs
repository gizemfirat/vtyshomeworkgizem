using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

namespace Vtys.Homework.WebApi.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        [Route("api/userRoles")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _userRoleService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }
    }
}
