using MediatR;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class DeleteIncomeInformationCommand : IRequest<DeleteIncomeInformationCommandResponse>
{
    public DeleteIncomeInformationCommand(string userId, int incomeId)
    {
        UserId = userId;
        IncomeId = incomeId;
    }

    public string UserId { get; set; }
    public int IncomeId { get; set; }
}