using System.ComponentModel.DataAnnotations;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class PostTaxDeduction
{
    [Key]
    public int PostTaxDeductionId { get; set; }
    public decimal Roth401KPercentage { get; set; }
    public decimal EmployeeStockPlanAmount { get; set; }
    public decimal AccidentInsuranceAmount { get; set; }
    public decimal LifeInsuranceAmount { get; set; }
    public decimal MiscellaneousAmount { get; set; }
}