using Api.Controllers;
using Api.Services.Contracts;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace v1.Api
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleController : ApiControllerBase
    {
        private readonly ISampleService sampleService;

        public SampleController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        [HttpGet("{message?}")]
        public async Task<IActionResult> Get(string message = null) =>
            await BuildResponse(sampleService.HelloSample(message));
    }
}
