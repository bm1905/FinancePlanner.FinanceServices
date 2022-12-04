using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class PayInformation
{
    [Key] 
    public int PayInformationId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string EmployeeName { get; set; } = string.Empty;
    [ForeignKey("BiWeeklyHoursAndRateId")] 
    public virtual BiWeeklyHoursAndRate BiWeeklyHoursAndRate { get; set; } = new();
    [ForeignKey("PostTaxDeductionId")]
    public virtual PostTaxDeduction PostTaxDeduction { get; set; } = new();
    [ForeignKey("PreTaxDeductionId")]
    public virtual PreTaxDeduction PreTaxDeduction { get; set; } = new();
    [ForeignKey("TaxInformationId")]
    public virtual TaxInformation TaxInformation { get; set; } = new();
}