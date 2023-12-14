using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class ProjectStatusHistoryController : Controller
    {
        private readonly IProjectStatusHistoryService _projectStatusHistoryService;

        public ProjectStatusHistoryController(IProjectStatusHistoryService projectStatusHistoryService)
        {
            _projectStatusHistoryService = projectStatusHistoryService;
        }

        [HttpGet]
        [Route("api/projectStatusHistories")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusHistoryService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projectStatusHistories/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusHistoryService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/projectStatusHistories")]
        public IActionResult Save([FromBody] ProjectStatusHistory projectStatusHistory)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusHistoryService.Save(projectStatusHistory).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/projectStatusHistories/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectStatusHistoryService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
