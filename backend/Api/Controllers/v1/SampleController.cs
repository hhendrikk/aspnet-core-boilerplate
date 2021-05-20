namespace Api.Controllers.V1
{
    using System.Threading.Tasks;
    using Api.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleController : ApiControllerBase
    {
    }
}