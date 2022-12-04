using System.ComponentModel.DataAnnotations;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class PreTaxDeduction
{
    [Key] 
    public int PreTaxDeductionId { get; set; }
    public decimal Medical { get; set; }
    public decimal Dental { get; set; }
    public decimal Vision { get; set; }
    public decimal Traditional401KPercentage { get; set; }
    public decimal HealthSavingAccountAmount { get; set; }
    public decimal MiscellaneousAmount { get; set; }
}