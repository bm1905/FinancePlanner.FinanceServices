using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace FinancePlanner.FinanceServices.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        ValidationContext<TRequest> context = new(request);
        ValidationResult[] validationResults =
            await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        List<ValidationFailure> failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
        if (failures.Count != 0) throw new ValidationException($"One or more validations errors occurred. {string.Join(", ", failures)}");
        return await next();
    }
}