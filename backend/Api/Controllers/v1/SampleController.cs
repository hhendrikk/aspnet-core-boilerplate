namespace Api.Controllers.V1;

using Api.Controllers;
using Infrastructure;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SampleController : ApiControllerBase
{
    [HttpGet("hello-world")]
    public Task<IActionResult> GetHelloWorldAsync(CancellationToken cancellation) =>
        BuildResponseAsync(EitherAsync<Notification, string>.RightAsync(Task.FromResult("Hello World")));
}