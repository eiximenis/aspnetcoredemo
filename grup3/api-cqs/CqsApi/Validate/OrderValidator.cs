using CqsApi.Dtos;
using FluentValidation;

namespace CqsApi.Validate
{

    public class NewOrderCommandValidator : AbstractValidator<AddNewOrderCommand>
    {
        public NewOrderCommandValidator()
        {
            RuleFor(c => c.Order).SetValidator(new OrderValidator());
        }
    }

    public class OrderValidator : AbstractValidator<OrderInputDto>
    {
        public OrderValidator()
        {
            RuleFor(l => l.Lines).NotEmpty();
        }
    }
}
