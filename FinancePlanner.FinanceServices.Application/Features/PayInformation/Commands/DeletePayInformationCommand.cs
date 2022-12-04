using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class DeletePayInformationCommand : IRequest<DeletePayInformationCommandResponse>
{
    public DeletePayInformationCommand(string userId, int payId)
    {
        UserId = userId;
        PayId = payId;
    }
    
    public string UserId { get; set; }
    public int PayId { get; set; }
}