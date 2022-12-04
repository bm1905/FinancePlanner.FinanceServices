using FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;
using FinancePlanner.FinanceServices.Application.Features.PayInformation.Queries;
using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Services.PayInformationServices;

public interface IPayInformationService
{
    Task<SavePayInformationCommandResponse> Save(PayInformationRequest request, string? userId, int? payId);
    Task<GetPayInformationQueryResponse> Get(string userId, int? payId);
    Task<DeletePayInformationCommandResponse> Delete(string userId, int payId);
}