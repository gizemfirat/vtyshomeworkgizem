using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

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

        [HttpGet]
        [Route("api/projectSources/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectSourceService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/projectSources")]
        public IActionResult Save([FromBody] ProjectSource projectSource)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectSourceService.Save(projectSource).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/projectSources/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectSourceService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
