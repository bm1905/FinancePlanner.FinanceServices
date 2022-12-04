using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;

public class GetIncomeInformationQueryResponse
{
    public List<IncomeInformationResponse> IncomeInformation { get; set; } = new();
}