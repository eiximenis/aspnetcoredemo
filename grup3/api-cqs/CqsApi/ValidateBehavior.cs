using FluentValidation;
using FluentValidation.Results;
using MediatR;


namespace CqsApi
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);

            var result = new List<ValidationResult>();
            foreach (var validator in _validators)
            {
                result.Add(await validator.ValidateAsync(context));
            }
            var errors = result.Where(r => !r.IsValid).SelectMany(r => r.Errors);
            if (errors.Any())
            {
                throw new ValidationException("Error on valudation", errors);
            }
            return await next();
        }
    }
}
