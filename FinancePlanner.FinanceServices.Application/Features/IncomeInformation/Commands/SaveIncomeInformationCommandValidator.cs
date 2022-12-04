using FluentValidation;

namespace FinancePlanner.FinanceServices.Application.Features.IncomeInformation.Commands;

public class SaveIncomeInformationCommandValidator : AbstractValidator<SaveIncomeInformationCommand>
{
    public SaveIncomeInformationCommandValidator()
    {
        RuleFor(p => p.RequestModel.UserId)
            .NotEmpty().WithMessage("UserId should not be empty")
            .NotNull().WithMessage("UserId should not be null");
        RuleFor(p => p.RequestModel.EmployeeName)
            .NotEmpty().WithMessage("EmployeeName should not be empty")
            .NotNull().WithMessage("EmployeeName should not be null");
        RuleFor(p => p.RequestModel.PayInformationId)
            .NotEmpty().WithMessage("PayInformationId should not be empty")
            .NotNull().WithMessage("PayInformationId should not be null");
        RuleFor(p => p.RequestModel.GrossPay)
            .NotEmpty().WithMessage("GrossPay should not be empty")
            .NotNull().WithMessage("GrossPay should not be null");
        RuleFor(p => p.RequestModel.NetPay)
            .NotEmpty().WithMessage("NetPay should not be empty")
            .NotNull().WithMessage("NetPay should not be null");
        RuleFor(p => p.RequestModel.TotalHours)
            .NotEmpty().WithMessage("TotalHours should not be empty")
            .NotNull().WithMessage("TotalHours should not be null");
        RuleFor(p => p.RequestModel.PayRate)
            .NotEmpty().WithMessage("PayRate should not be empty")
            .NotNull().WithMessage("PayRate should not be null");
    }
}