using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class TaskStatusHistoryController : Controller
    {
        private readonly ITaskStatusHistoryService _taskStatusHistoryService;

        public TaskStatusHistoryController(ITaskStatusHistoryService taskStatusHistoryService)
        {
            _taskStatusHistoryService = taskStatusHistoryService;
        }

        [HttpGet]
        [Route("api/taskStatusHistories")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusHistoryService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/taskStatusHistories/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusHistoryService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/taskStatusHistories")]
        public IActionResult Save([FromBody] TaskStatusHistory taskStatusHistory)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusHistoryService.Save(taskStatusHistory).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/taskStatusHistories/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskStatusHistoryService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
