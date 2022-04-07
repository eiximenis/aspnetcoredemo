using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqsApi
{
    static class OrdersCommands
    {
        public static async Task<IResult> AddNewOrder([FromServices] IMediator mediator, AddNewOrderCommand command)
        {
            await mediator.Send(command);

            return Results.Ok();
        }
    }
}
