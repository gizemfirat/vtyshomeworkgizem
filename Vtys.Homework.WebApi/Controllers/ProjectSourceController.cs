using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

namespace Vtys.Homework.WebApi.Controllers
{
    public class ProjectSourceController : Controller
    {
        private readonly IProjectSourceService _projectSourceService;

        public ProjectSourceController(IProjectSourceService projectSourceService)
        {
            _projectSourceService = projectSourceService;
        }

        [HttpGet]
        [Route("api/projectSources")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectSourceService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }
    }
}
