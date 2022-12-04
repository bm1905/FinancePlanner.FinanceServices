using System.ComponentModel.DataAnnotations;

namespace FinancePlanner.FinanceServices.Domain.Entities;

public class BiWeeklyHoursAndRate
{
    [Key]
    public int BiWeeklyHoursAndRateId { get; set; }
    public decimal HourlyRate { get; set; }
    public decimal Week1TotalHours { get; set; }
    public decimal Week1TimeOffHours { get; set; }
    public decimal Week2TotalHours { get; set; }
    public decimal Week2TimeOffHours { get; set; }
}