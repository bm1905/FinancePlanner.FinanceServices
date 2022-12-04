using System.ComponentModel.DataAnnotations;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class TaxableWageInformation
{
    [Key] 
    public int TaxableWageInformationId { get; set; }
    public decimal StateAndFederalTaxableWages { get; set; }
    public decimal SocialAndMedicareTaxableWages { get; set; }
}