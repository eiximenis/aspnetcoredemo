using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ordering.Data;
using Ordering.DatabaseSimulator;
using Ordering.Domain;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrdersQueriesController : ControllerBase
    {
        private readonly OrderingContext _db;
        public OrdersQueriesController(OrderingContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll() => _db.Orders.AsNoTracking();

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<Order> GetById(int id)
        {
            var order = _db.Orders.Include(o => o.Lines)
                .SingleOrDefault(o => o.Id == id);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }

}

