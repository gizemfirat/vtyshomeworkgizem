using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class TaskSourceController : Controller
    {
        private readonly ITaskSourceService _taskSourceService;

        public TaskSourceController(ITaskSourceService taskSourceService)
        {
            _taskSourceService = taskSourceService;
        }

        [HttpGet]
        [Route("api/taskSources")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskSourceService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/taskSources/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskSourceService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/taskSources")]
        public IActionResult Save([FromBody] TaskSource taskSource)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskSourceService.Save(taskSource).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/taskSources/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskSourceService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
