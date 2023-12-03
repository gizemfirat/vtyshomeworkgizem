using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Business.Models;

namespace Vtys.Homework.WebApi.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService) 
        {
            _securityService = securityService;
        }

        [HttpPost]
        [Route("api/security/register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _securityService.Register(model).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
