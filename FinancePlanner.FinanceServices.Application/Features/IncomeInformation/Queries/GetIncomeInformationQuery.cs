using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;

public class GetIncomeInformationQuery : IRequest<GetIncomeInformationQueryResponse>
{
    public GetIncomeInformationQuery(string userId)
    {
        UserId = userId;
    }

    public GetIncomeInformationQuery(string userId, int? incomeId)
    {
        UserId = userId;
        IncomeId = incomeId;
    }

    public string UserId { get; set; }
    public int? IncomeId { get; set; }
}