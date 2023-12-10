using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class TaskStatusController : Controller
    {
        private readonly ITaskStatusService _taskStatusService;

        public TaskStatusController(ITaskStatusService taskStatusService)
        {
            _taskStatusService = taskStatusService;
        }

        [HttpGet]
        [Route("api/taskStatuses")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/taskStatuses/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/taskStatuses")]
        public IActionResult Save([FromBody] Entities.Concrete.TaskStatus taskStatus)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusService.Save(taskStatus).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/taskStatuses/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
