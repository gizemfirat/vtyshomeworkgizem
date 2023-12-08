using Microsoft.AspNetCore.Mvc;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.Business.Abstract;

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
    }
}
