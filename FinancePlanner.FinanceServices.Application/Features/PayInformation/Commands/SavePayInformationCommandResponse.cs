using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class SavePayInformationCommandResponse
{
    public PayInformationResponse PayInformationResponse { get; set; } = new();
}