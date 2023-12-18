using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class TaskController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("api/tasks")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/tasks/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/tasks")]
        public IActionResult Save([FromBody] TaskSavingModel task)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.Save(task).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/tasks/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/tasks/taskSources")]
        public IActionResult GetWithAllDetail()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.GetAllSources().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/tasks/{id}/history")]
        public IActionResult GetHistory(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _taskService.GetHistory(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
