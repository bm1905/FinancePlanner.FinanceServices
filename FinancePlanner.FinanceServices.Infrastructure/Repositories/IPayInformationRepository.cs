using System.Collections.Generic;
using FinancePlanner.FinanceServices.Domain.Entities;
using System.Threading.Tasks;

namespace FinancePlanner.FinanceServices.Infrastructure.Repositories;

public interface IPayInformationRepository
{
    Task<bool> Save(PayInformation payInformation);
    Task<bool> Update(PayInformation payInformation);
    Task<bool> DeleteOne(string userId, int payId);
    Task<List<PayInformation>?> GetAll(string userId);
    Task<PayInformation?> GetOne(string userId, int payId);
}