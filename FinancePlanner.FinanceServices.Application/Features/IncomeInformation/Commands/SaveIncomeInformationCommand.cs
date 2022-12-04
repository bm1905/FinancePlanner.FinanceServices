using FinancePlanner.Shared.Models.FinanceServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class SaveIncomeInformationCommand : IRequest<SaveIncomeInformationCommandResponse>
{
    public SaveIncomeInformationCommand(IncomeInformationRequest requestModel)
    {
        RequestModel = requestModel;
    }

    public SaveIncomeInformationCommand(IncomeInformationRequest requestModel, string? userId, int? incomeId)
    {
        RequestModel = requestModel;
        UserId = userId;
        IncomeId = incomeId;
    }

    public IncomeInformationRequest RequestModel { get; set; }
    public string? UserId { get; set; }
    public int? IncomeId { get; set; }
}