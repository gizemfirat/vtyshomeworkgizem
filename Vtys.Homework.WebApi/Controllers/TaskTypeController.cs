using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class TaskTypeController : Controller
    {
        private readonly ITaskTypeService _taskTypeService;

        public TaskTypeController(ITaskTypeService taskTypeService)
        {
            _taskTypeService = taskTypeService;
        }

        [HttpGet]
        [Route("api/taskTypes")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskTypeService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/taskTypes/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskTypeService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/taskTypes")]
        public IActionResult Save([FromBody] TaskType taskType)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskTypeService.Save(taskType).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/taskTypes/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskTypeService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
