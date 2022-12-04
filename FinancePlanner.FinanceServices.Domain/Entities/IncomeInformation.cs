using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class IncomeInformation
{
    [Key]
    public int IncomeInformationId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string EmployeeName { get; set; } = string.Empty;
    public int PayInformationId { get; set; }
    public decimal GrossPay { get; set; }
    public decimal NetPay { get; set; }
    public decimal TotalHours { get; set; }
    public decimal PayRate { get; set; }
    public decimal TotalPreTaxDeductions { get; set; }
    public decimal TotalPostTaxDeductions { get; set; }
    [ForeignKey("TaxableWageInformationId")]
    public virtual TaxableWageInformation TaxableWageInformation { get; set; } = new();
    [ForeignKey("TaxWithheldInformationId")]
    public virtual TaxWithheldInformation TaxWithheldInformation { get; set; } = new();
}