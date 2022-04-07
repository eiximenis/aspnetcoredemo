using Cqs.Domain;
using CqsApi.Dtos;
using CqsApi.Extensions;
using MediatR;

namespace CqsApi
{
    public class AddNewOrderCommand : IRequest<Unit>
    {
        public OrderInputDto Order { get; set; }
    }

    public class AddNewOrderCommandHandler : IRequestHandler<AddNewOrderCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderRepository _orderRepository;
        public AddNewOrderCommandHandler(IUnitOfWork uow, IOrderRepository repo)
        {
            _uow = uow;
            _orderRepository = repo;
        }

        public async Task<Unit> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Add(request.Order.ToEntity());
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}