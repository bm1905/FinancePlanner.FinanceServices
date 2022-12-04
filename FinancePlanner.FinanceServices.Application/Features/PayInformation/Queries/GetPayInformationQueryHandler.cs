using FinancePlanner.FinanceServices.Application.Services.PayInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Queries;

public class GetPayInformationQueryHandler : IRequestHandler<GetPayInformationQuery, GetPayInformationQueryResponse>
{
    private readonly IPayInformationService _payInformationService;

    public GetPayInformationQueryHandler(IPayInformationService payInformationService)
    {
        _payInformationService = payInformationService;
    }

    public async Task<GetPayInformationQueryResponse> Handle(GetPayInformationQuery request, CancellationToken cancellationToken)
    {
        GetPayInformationQueryResponse response = await _payInformationService.Get(request.UserId, request.PayId);
        return response;
    }
}