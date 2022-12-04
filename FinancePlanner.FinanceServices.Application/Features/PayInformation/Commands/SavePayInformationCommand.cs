using FinancePlanner.Shared.Models.FinanceServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class SavePayInformationCommand : IRequest<SavePayInformationCommandResponse>
{
    public SavePayInformationCommand(PayInformationRequest requestModel)
    {
        RequestModel = requestModel;
    }

    public SavePayInformationCommand(PayInformationRequest requestModel, string? userId, int? payId)
    {
        RequestModel = requestModel;
        UserId = userId;
        PayId = payId;
    }

    public PayInformationRequest RequestModel { get; set; }
    public string? UserId { get; set; }
    public int? PayId { get; set; }
}