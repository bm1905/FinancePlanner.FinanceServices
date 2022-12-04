using FinancePlanner.FinanceServices.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancePlanner.FinanceServices.Infrastructure.Repositories;

public interface IIncomeInformationRepository
{
    Task<bool> Save(IncomeInformation incomeInformation);
    Task<bool> Update(IncomeInformation incomeInformation);
    Task<bool> DeleteOne(string userId, int incomeId);
    Task<List<IncomeInformation>?> GetAll(string userId);
    Task<IncomeInformation?> GetOne(string userId, int incomeId);
}