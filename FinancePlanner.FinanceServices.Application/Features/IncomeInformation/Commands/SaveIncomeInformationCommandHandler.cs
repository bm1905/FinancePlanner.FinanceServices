using FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class SaveIncomeInformationCommandHandler : IRequestHandler<SaveIncomeInformationCommand, SaveIncomeInformationCommandResponse>
{
    private readonly IIncomeInformationService _incomeInformationService;

    public SaveIncomeInformationCommandHandler(IIncomeInformationService incomeInformationService)
    {
        _incomeInformationService = incomeInformationService;
    }

    public async Task<SaveIncomeInformationCommandResponse> Handle(SaveIncomeInformationCommand request, CancellationToken cancellationToken)
    {
        SaveIncomeInformationCommandResponse response = await _incomeInformationService.Save(request.RequestModel, request.UserId, request.IncomeId);
        return response;
    }
}