using MediatR;
using Ordering.Domain;

namespace Ordering.Api.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IOrdersRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandHandler(IOrdersRepository repo, IUnitOfWork uow)
        {

            _repository = repo;
            _unitOfWork = uow;
        }
        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToAdd = request.GetOrder();
            await _repository.AddOrder(orderToAdd);
            await _unitOfWork.SaveChangesAsync();
            return orderToAdd.Id;
        }
    }
}
