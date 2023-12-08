using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

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
    }
}
