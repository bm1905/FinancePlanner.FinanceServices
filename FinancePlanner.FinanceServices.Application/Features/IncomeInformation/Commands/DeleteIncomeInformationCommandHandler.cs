using FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class DeleteIncomeInformationCommandHandler : IRequestHandler<DeleteIncomeInformationCommand, DeleteIncomeInformationCommandResponse>
{
    private readonly IIncomeInformationService _incomeInformationService;

    public DeleteIncomeInformationCommandHandler(IIncomeInformationService incomeInformationService)
    {
        _incomeInformationService = incomeInformationService;
    }

    public async Task<DeleteIncomeInformationCommandResponse> Handle(DeleteIncomeInformationCommand request, CancellationToken cancellationToken)
    {
        DeleteIncomeInformationCommandResponse response = await _incomeInformationService.Delete(request.UserId, request.IncomeId);
        return response;
    }
}