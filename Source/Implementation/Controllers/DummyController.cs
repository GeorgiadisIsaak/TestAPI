using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Types.Requests;
using Types.Responses;

namespace Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController: ControllerBase
    {
        private readonly ILogger<DummyController> _logger;
        private readonly IDummyService _dummyService;

        public DummyController(ILogger<DummyController> logger, IDummyService dummyService)
        {
            _logger = logger;
            _dummyService = dummyService;
        }

        /// <summary>
        /// Retrieves the requested item
        /// </summary>
        /// <response code="200">The requested item</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Exception info</response>
        [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("Item")]
        public async Task<IActionResult> Item([FromQuery] ItemRequest itemRequest)
        {
            var response = await _dummyService.GetItem(itemRequest);

            return Ok(response);
        }
    }
}