using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;
using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;
using FinancePlanner.Shared.Models.FinanceServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancePlanner.FinanceServices.Services.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("ApiScope")]
public class IncomeInformationController : ControllerBase
{
    private readonly IMediator _mediator;
        
    public IncomeInformationController(IMediator mediator)
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
    [ProducesResponseType(typeof(ActionResult<IncomeInformationResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IncomeInformationResponse>> Save([FromBody] IncomeInformationRequest request)
    {
        SaveIncomeInformationCommand command = new SaveIncomeInformationCommand(request);
        SaveIncomeInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.IncomeInformationResponse);
    }

    [MapToApiVersion("1.0")]
    [HttpPost("Update/{userId}/{incomeId:int}")]
    [ProducesResponseType(typeof(ActionResult<IncomeInformationResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IncomeInformationResponse>> Update([FromBody] IncomeInformationRequest request, string userId, int incomeId)
    {
        SaveIncomeInformationCommand command = new SaveIncomeInformationCommand(request, userId, incomeId);
        SaveIncomeInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.IncomeInformationResponse);
    }

    [MapToApiVersion("1.0")]
    [HttpGet("Get/{userId}")]
    [ProducesResponseType(typeof(ActionResult<List<IncomeInformationResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IncomeInformationResponse>> Get(string userId)
    {
        GetIncomeInformationQuery query = new GetIncomeInformationQuery(userId);
        GetIncomeInformationQueryResponse result = await _mediator.Send(query);
        return Ok(result.IncomeInformation);
    }

    [MapToApiVersion("1.0")]
    [HttpGet("Get/{userId}/{incomeId:int}")]
    [ProducesResponseType(typeof(ActionResult<List<IncomeInformationResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<IncomeInformationResponse>>> Get(string userId, int incomeId)
    {
        GetIncomeInformationQuery query = new GetIncomeInformationQuery(userId, incomeId);
        GetIncomeInformationQueryResponse result = await _mediator.Send(query);
        return Ok(result.IncomeInformation);
    }

    [MapToApiVersion("1.0")]
    [HttpDelete("Delete/{userId}/{incomeId:int}")]
    [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IncomeInformationResponse>> Delete(string userId, int incomeId)
    {
        DeleteIncomeInformationCommand command = new DeleteIncomeInformationCommand(userId, incomeId);
        DeleteIncomeInformationCommandResponse result = await _mediator.Send(command);
        return Ok(result.IsSuccessful);
    }
}