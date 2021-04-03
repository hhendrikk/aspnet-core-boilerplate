namespace Api.Controllers.V1
{
    using Controllers;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Threading.Tasks;

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleController : ApiControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }


        [Authorize]
        [HttpGet("{message?}")]
        public async Task<IActionResult> Get(string message = null) =>
            await BuildResponse(_sampleService.HelloSample(message));
    }
}
