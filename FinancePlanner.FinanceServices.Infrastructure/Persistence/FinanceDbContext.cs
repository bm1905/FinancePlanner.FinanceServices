using FinancePlanner.FinanceServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancePlanner.FinanceServices.Infrastructure.Persistence;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }

    public DbSet<PayInformation>? PayInformation { get; set; } = default;
    public DbSet<BiWeeklyHoursAndRate>? BiWeeklyHoursAndRates { get; set; }
    public DbSet<PostTaxDeduction>? PostTaxDeductions { get; set; }
    public DbSet<PreTaxDeduction>? PreTaxDeductions { get; set; }
    public DbSet<TaxInformation>? TaxInformation { get; set; }
    public DbSet<IncomeInformation>? IncomeInformation { get; set; }
    public DbSet<TaxWithheldInformation>? TaxWithheldInformation { get; set; }
    public DbSet<TaxableWageInformation>? TaxableWageInformation { get; set; }
}