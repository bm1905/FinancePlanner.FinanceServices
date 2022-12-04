using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;
using FinancePlanner.FinanceServices.Application.Features.PayInformation.Queries;
using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Services.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("ApiScope")]
public class PayInformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public PayInformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [MapToApiVersion("1.0")]
    [HttpGet("Test")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    public IActionResult Index()
    {
        return Ok(new { Status = "V1 Test Passed" });
    }

    [MapToApiVersion("1.0")]
    [HttpPost("Save")]
    [ProducesResponseType(typeof(ActionResult<PayInformationResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PayInformationResponse>> Save([FromBody] PayInformationRequest request)
    {
        SavePayInformationCommand command = new SavePayInformationCommand(request);
        SavePayInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.PayInformationResponse);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("Update/{userId}/{payId:int}")]
    [ProducesResponseType(typeof(ActionResult<PayInformationResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PayInformationResponse>> Update([FromBody] PayInformationRequest request, string userId, int payId)
    {
        SavePayInformationCommand command = new SavePayInformationCommand(request, userId, payId);
        SavePayInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.PayInformationResponse);
    }

    [MapToApiVersion("1.0")]
    [HttpGet("Get/{userId}")]
    [ProducesResponseType(typeof(ActionResult<List<PayInformationResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PayInformationResponse>> Get(string userId)
    {
        GetPayInformationQuery query = new GetPayInformationQuery(userId);
        GetPayInformationQueryResponse result = await _mediator.Send(query);
        return Ok(result.PayInformation);
    }

    [MapToApiVersion("1.0")]
    [HttpGet("Get/{userId}/{payId:int}")]
    [ProducesResponseType(typeof(ActionResult<List<PayInformationResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PayInformationResponse>>> Get(string userId, int payId)
    {
        GetPayInformationQuery query = new GetPayInformationQuery(userId, payId);
        GetPayInformationQueryResponse result = await _mediator.Send(query);
        return Ok(result.PayInformation);
    }

    [MapToApiVersion("1.0")]
    [HttpDelete("Delete/{userId}/{payId:int}")]
    [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PayInformationResponse>> Delete(string userId, int payId)
    {
        DeletePayInformationCommand command = new DeletePayInformationCommand(userId, payId);
        DeletePayInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.IsSuccessful);
    }
}