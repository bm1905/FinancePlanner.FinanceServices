using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class SaveIncomeInformationCommandResponse
{
    public IncomeInformationResponse IncomeInformationResponse { get; set; } = new();
}