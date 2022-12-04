using System.ComponentModel.DataAnnotations;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class TaxWithheldInformation
{
    [Key] 
    public int TaxWithheldInformationId { get; set; }
    public decimal FederalTaxWithheldAmount { get; set; }
    public decimal MedicareWithheldAmount { get; set; }
    public decimal SocialSecurityWithheldAmount { get; set; }
    public decimal StateTaxWithheldAmount { get; set; }
    public decimal TotalTaxesWithheldAmount { get; set; }
}