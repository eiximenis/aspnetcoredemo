using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Api.Commands;
using Ordering.Domain;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrdersCommandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersCommandsController( IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderCommand command)
        {
            var newId = await _mediator.Send(command);
            return CreatedAtAction("GetById", "OrdersQueries", new {id = newId}, null);
        }

    }
}
