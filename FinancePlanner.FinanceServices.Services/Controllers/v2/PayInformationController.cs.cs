using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinancePlanner.FinanceServices.Services.Controllers.v2;

[ApiController]
//[Authorize]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PayInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public PayInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [MapToApiVersion("2.0")]
    [HttpGet("Test")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    public IActionResult Index()
    {
        return Ok(new { Status = "V2 Test Passed" });
    }
}