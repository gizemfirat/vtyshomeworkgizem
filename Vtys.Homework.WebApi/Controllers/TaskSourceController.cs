using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

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
    }
}
