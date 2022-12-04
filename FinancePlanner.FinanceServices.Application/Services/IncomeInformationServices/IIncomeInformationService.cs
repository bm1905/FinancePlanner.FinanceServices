using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;
using FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Queries;
using FinancePlanner.Shared.Models.FinanceServices;

namespace FinancePlanner.FinanceServices.Application.Services.IncomeInformationServices;

public interface IIncomeInformationService
{
    Task<SaveIncomeInformationCommandResponse> Save(IncomeInformationRequest request, string? userId, int? incomeId);
    Task<GetIncomeInformationQueryResponse> Get(string userId, int? incomeId);
    Task<DeleteIncomeInformationCommandResponse> Delete(string userId, int incomeId);
}