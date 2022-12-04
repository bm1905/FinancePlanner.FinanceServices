using FinancePlanner.FinanceServices.Application.Services.PayInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class SavePayInformationCommandHandler : IRequestHandler<SavePayInformationCommand, SavePayInformationCommandResponse>
{
    private readonly IPayInformationService _payInformationService;

    public SavePayInformationCommandHandler(IPayInformationService payInformationService)
    {
        _payInformationService = payInformationService;
    }

    public async Task<SavePayInformationCommandResponse> Handle(SavePayInformationCommand request, CancellationToken cancellationToken)
    {
        SavePayInformationCommandResponse response = await _payInformationService.Save(request.RequestModel, request.UserId, request.PayId);
        return response;
    }
}