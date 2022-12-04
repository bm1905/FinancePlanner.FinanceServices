using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancePlanner.FinanceServices.Domain.Entities;
using FinancePlanner.FinanceServices.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinancePlanner.FinanceServices.Infrastructure.Repositories;

public class IncomeInformationRepository : IIncomeInformationRepository
{
    private readonly FinanceDbContext _dbContext;

    public IncomeInformationRepository(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Save(IncomeInformation incomeInformation)
    {
        await _dbContext.AddAsync(incomeInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(IncomeInformation incomeInformation)
    {
        _dbContext.UpdateRange(incomeInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteOne(string userId, int incomeId)
    {
        if (_dbContext.IncomeInformation == null) return false;
        IncomeInformation? incomeInformation = await _dbContext.IncomeInformation.Where(x => x.UserId == userId && x.IncomeInformationId == incomeId)
            .Include(x => x.TaxableWageInformation)
            .Include(x => x.TaxWithheldInformation)
            .FirstOrDefaultAsync();
        if (incomeInformation == null) return false;
        _dbContext.Remove(incomeInformation.TaxableWageInformation);
        _dbContext.Remove(incomeInformation.TaxWithheldInformation);
        _dbContext.Remove(incomeInformation);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<IncomeInformation>?> GetAll(string userId)
    {
        if (_dbContext.IncomeInformation == null) return default;
        List<IncomeInformation> incomeInformationList = await _dbContext.IncomeInformation.Where(x => x.UserId == userId)
            .Include(x => x.TaxableWageInformation)
            .Include(x => x.TaxWithheldInformation)
            .AsNoTracking()
            .ToListAsync();
        return incomeInformationList;
    }

    public async Task<IncomeInformation?> GetOne(string userId, int incomeId)
    {
        if (_dbContext.IncomeInformation == null) return default;
        IncomeInformation? incomeInformation = await _dbContext.IncomeInformation.Where(x => x.UserId == userId && x.IncomeInformationId == incomeId)
            .Include(c => c.TaxableWageInformation)
            .Include(x => x.TaxWithheldInformation)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return incomeInformation;
    }
}