using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Queries;

public class GetPayInformationQuery : IRequest<GetPayInformationQueryResponse>
{
    public GetPayInformationQuery(string userId)
    {
        UserId = userId;
    }

    public GetPayInformationQuery(string userId, int? payId)
    {
        UserId = userId;
        PayId = payId;
    }

    public string UserId { get; set; }
    public int? PayId { get; set; }
}