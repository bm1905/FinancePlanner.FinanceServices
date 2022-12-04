using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancePlanner.FinanceServices.Domain.Entities;
using FinancePlanner.FinanceServices.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinancePlanner.FinanceServices.Infrastructure.Repositories;

public class PayInformationRepository : IPayInformationRepository
{
    private readonly FinanceDbContext _dbContext;

    public PayInformationRepository(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Save(PayInformation payInformation)
    {
        await _dbContext.AddAsync(payInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(PayInformation payInformation)
    {
        _dbContext.Update(payInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<PayInformation>?> GetAll(string userId)
    {
        if (_dbContext.PayInformation == null) return default;
        List<PayInformation> payInformationList = await _dbContext.PayInformation
            .Where(x => x.UserId == userId)
            .Include(x => x.TaxInformation)
            .Include(x => x.PreTaxDeduction)
            .Include(x => x.PostTaxDeduction)
            .Include(x => x.BiWeeklyHoursAndRate)
            .AsNoTracking()
            .ToListAsync();

        return payInformationList;
    }

    public async Task<PayInformation?> GetOne(string userId, int payId)
    {
        if (_dbContext.PayInformation == null) return default;
        PayInformation? payInformation = await _dbContext.PayInformation
            .Where(x => x.UserId == userId && x.PayInformationId == payId)
            .Include(x => x.TaxInformation)
            .Include(x => x.PreTaxDeduction)
            .Include(x => x.PostTaxDeduction)
            .Include(x => x.BiWeeklyHoursAndRate)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return payInformation;
    }

    public async Task<bool> DeleteOne(string userId, int payId)
    {
        if (_dbContext.PayInformation == null) return false;
        PayInformation? payInformation = await _dbContext.PayInformation.Where(x => x.UserId == userId && x.PayInformationId == payId)
            .Include(e => e.BiWeeklyHoursAndRate)
            .Include(e => e.PostTaxDeduction)
            .Include(e => e.PreTaxDeduction)
            .Include(e => e.TaxInformation)
            .FirstOrDefaultAsync();
        if (payInformation == null) return false;
        _dbContext.Remove(payInformation.BiWeeklyHoursAndRate);
        _dbContext.Remove(payInformation.PostTaxDeduction);
        _dbContext.Remove(payInformation.PreTaxDeduction);
        _dbContext.Remove(payInformation.TaxInformation);
        _dbContext.Remove(payInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}