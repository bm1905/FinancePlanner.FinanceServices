using FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;

public class GetIncomeInformationQueryHandler : IRequestHandler<GetIncomeInformationQuery, GetIncomeInformationQueryResponse>
{
    private readonly IIncomeInformationService _incomeInformationService;

    public GetIncomeInformationQueryHandler(IIncomeInformationService incomeInformationService)
    {
        _incomeInformationService = incomeInformationService;
    }

    public async Task<GetIncomeInformationQueryResponse> Handle(GetIncomeInformationQuery request, CancellationToken cancellationToken)
    {
        GetIncomeInformationQueryResponse response = await _incomeInformationService.Get(request.UserId, request.IncomeId);
        return response;
    }
}