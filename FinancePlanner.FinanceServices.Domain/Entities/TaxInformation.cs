using System.ComponentModel.DataAnnotations;
using FinancePlanner.FinanceServices.Domain.Enums;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class TaxInformation
{
    [Key]
    public int TaxInformationId { get; set; }
    public W4Type W4Type { get; set; }
    public TaxFilingStatus TaxFilingStatus { get; set; }
    public int PayPeriodNumber { get; set; }
    public string State { get; set; } = string.Empty;
    public bool IsMultipleJobsChecked { get; set; }
    public decimal ExtraWithholdingAmount { get; set; }
    public decimal DeductionsAmount { get; set; }
    public decimal OtherIncomeAmount { get; set; }
    public decimal ClaimDependentsAmount { get; set; }
    public int AllowanceNumber { get; set; }
}