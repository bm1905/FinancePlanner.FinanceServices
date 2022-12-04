using FinancePlanner.Shared.Models.Enums;
using FluentValidation;

namespace FinancePlanner.FinanceServices.Application.Features.PayInformation.Commands;

public class SavePayInformationCommandValidator : AbstractValidator<SavePayInformationCommand>
{
    public SavePayInformationCommandValidator()
    {
        List<TaxFilingStatus> filingStatuses = Enum.GetValues(typeof(TaxFilingStatus)).Cast<TaxFilingStatus>().ToList();
        List<W4Type> w4Types = Enum.GetValues(typeof(W4Type)).Cast<W4Type>().ToList();

        RuleFor(p => p.RequestModel.TaxInformation.W4Type)
            .NotEmpty().WithMessage("W4Type is required")
            .NotNull().WithMessage("W4Type cannot be null")
            .Must(p => w4Types.Contains(p)).WithMessage($"Allowed values are 1, 2 for: {string.Join(", ", w4Types)}");

        RuleFor(p => p.RequestModel.TaxInformation.TaxFilingStatus)
            .NotEmpty().WithMessage("TaxFilingStatus should not be empty")
            .NotNull().WithMessage("TaxFilingStatus should not be null")
            .Must(p => filingStatuses.Contains(p)).WithMessage($"Allowed values are 1, 2, 3 for: {string.Join(", ", filingStatuses)}");

        RuleFor(p => p.RequestModel.TaxInformation.State)
            .NotEmpty().WithMessage("State should not be empty")
            .NotNull().WithMessage("State should not be null");
    }
}