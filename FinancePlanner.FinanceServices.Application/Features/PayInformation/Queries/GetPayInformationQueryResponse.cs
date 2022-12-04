using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Queries;

public class GetPayInformationQueryResponse
{
    public List<PayInformationResponse> PayInformation { get; set; } = new();
}