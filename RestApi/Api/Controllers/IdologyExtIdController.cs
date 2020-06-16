namespace Api.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Models.Configuration;
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class IdologyExtIdController : ControllerBase
    {
        private readonly ILogger<IdologyExtIdController> _logger;
        private readonly IIdologyService _service;
        private IOptions<IdologyConfig> _config;

        public IdologyExtIdController(
            ILogger<IdologyExtIdController> logger,
            IOptions<IdologyConfig> config,
            IIdologyService service
        )
        {
            _logger = logger;
            _config = config;
            _service = service;
        }

        [BasicAuth]
        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> ExpectId([FromBody] ExpectIdInput expectIdInput)
        {
            var output = await _service.ExpectIdCall(expectIdInput);

            if (!output.Success)
            {
                //return Conflict(new B2CResponse() { UserMessage = output.Error });
                return BadRequest(new ResponseContent("CONTOSOERR001", output.Error, HttpStatusCode.BadRequest, "ValidationError"));
            }

            return Ok(output);
        }
    }
}