using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class ProjectTypeController : Controller
    {
        private readonly IProjectTypeService _projectTypeService;

        public ProjectTypeController(IProjectTypeService projectTypeService)
        {
            _projectTypeService = projectTypeService;
        }

        [HttpGet]
        [Route("api/projectTypes")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectTypeService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projectTypes/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectTypeService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/projectTypes")]
        public IActionResult Save([FromBody] ProjectType projectType)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectTypeService.Save(projectType).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/projectTypes/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectTypeService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
