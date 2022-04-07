using CqsApi.Dtos;
using FluentValidation;

namespace CqsApi.Validate
{
    public class OrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public OrderLineValidator()
        {
            RuleFor(l => l.Description).NotEmpty();
            RuleFor(l => l.Price).GreaterThan(0);
        }
    }
}
