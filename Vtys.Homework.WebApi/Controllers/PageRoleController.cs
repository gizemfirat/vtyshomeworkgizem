using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

namespace Vtys.Homework.WebApi.Controllers
{
    public class PageRoleController : Controller
    {
        private readonly IPageRoleService _pageRoleService;

        public PageRoleController(IPageRoleService pageRoleService)
        {
            _pageRoleService = pageRoleService;
        }

        [HttpGet]
        [Route("api/pageRoles")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _pageRoleService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }
    }
}
