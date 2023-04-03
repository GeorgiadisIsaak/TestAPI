using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using Types.Responses;

namespace Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<ExceptionController> _logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        [Route("api/exception")]
        public IActionResult Exception()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            var response = new ExceptionResponse { Message = "Oops, something went wrong!", StatusCode = HttpStatusCode.InternalServerError };

            return StatusCode((int)response.StatusCode, response.Message);
        }
    }
}