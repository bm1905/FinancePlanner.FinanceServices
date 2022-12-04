using FinancePlanner.FinanceServices.Application.Services.PayInformationServices;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class DeletePayInformationCommandHandler : IRequestHandler<DeletePayInformationCommand, DeletePayInformationCommandResponse>
{
    private readonly IPayInformationService _payInformationService;

    public DeletePayInformationCommandHandler(IPayInformationService payInformationService)
    {
        _payInformationService = payInformationService;
    }

    public async Task<DeletePayInformationCommandResponse> Handle(DeletePayInformationCommand request, CancellationToken cancellationToken)
    {
        DeletePayInformationCommandResponse response = await _payInformationService.Delete(request.UserId, request.PayId);
        return response;
    }
}