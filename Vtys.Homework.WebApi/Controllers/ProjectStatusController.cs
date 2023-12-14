using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class ProjectStatusController : Controller
    {
        private readonly IProjectStatusService _projectStatusService;

        public ProjectStatusController(IProjectStatusService projectStatusService)
        {
            _projectStatusService = projectStatusService;
        }

        [HttpGet]
        [Route("api/projectStatuses")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projectStatuses/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/projectStatuses")]
        public IActionResult Save([FromBody] ProjectStatus projectStatus)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusService.Save(projectStatus).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/projectStatuses/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
