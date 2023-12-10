using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.WebApi.Controllers
{
    public class SourceController : Controller
    {
        private readonly ISourceService _sourceService;

        public SourceController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet]
        [Route("api/sources")]
        public IActionResult GetAll()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _sourceService.GetAll().ToJson(),
                StatusCode = 200,
            };
        }


        [HttpGet]
        [Route("api/sources/{id}")]
        public IActionResult GetById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _sourceService.GetById(id).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpPost]
        [Route("api/sources")]
        public IActionResult Save([FromBody] Source source)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _sourceService.Save(source).ToJson(),
                StatusCode = 200,
            };
        }

        [HttpDelete]
        [Route("api/sources/{id}")]
        public IActionResult DeleteById(long id)
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = _sourceService.DeleteById(id).ToJson(),
                StatusCode = 200,
            };
        }
    }
}
