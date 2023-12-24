using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class ProjectController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("api/projects")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projects/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/projects")]
        public IActionResult Save([FromBody] ProjectSavingModel model)
        {
             return new ContentResult
             {
                 ContentType = "application/json",
                 Content = _projectService.Save(model).ToJson(),
                 StatusCode = 200,
             };

        }

        [HttpDelete]
        [Route("api/projects/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projects/detail")]
        public IActionResult GetAllWithDetail()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetAllWithDetail().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projects/{projectId}/projectSources")]
        public IActionResult GetWithDetail(long projectId)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetSources(projectId).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projects/projectSources")]
        public IActionResult GetWithAllDetail()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetAllSources().ToJson(),
                StatusCode = 200,
            };
        }

        [HttpGet]
        [Route("api/projects/{id}/history")]
        public IActionResult GetHistory(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _projectService.GetHistory(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
