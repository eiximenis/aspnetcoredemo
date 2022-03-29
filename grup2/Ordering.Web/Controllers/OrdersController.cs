using Microsoft.AspNetCore.Mvc;
using Ordering.DatabaseSimulator;
using Ordering.Domain;
using Ordering.Web.Models;
using Ordering.Web.Services;

namespace Ordering.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ICatalogService _catalogService;
        private readonly OrderingDatabase _db;
        public OrdersController(ILogger<OrdersController> logger, 
            ICatalogService svc,
            OrderingDatabase database)
        {
            _logger = logger;
            _catalogService = svc;
            _db = database;
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var products = await _catalogService.GetProducts();
            var vm = new NewOrderViewModel();
            vm.OrderId = 0;
            vm.SetProductData(products);
            return View(vm);
        }

        public async Task<IActionResult> Index()
        {
            var orders = _db.GetAllOrders();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> New(NewOrderViewModel vm)
        {
            var products = await _catalogService.GetProducts();
            vm.SetProductData(products);
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Order order = null;
            if (vm.OrderId == 0)
            {
                order = new Order();
            }
            else
            {
                order =  _db.GetOrderById(vm.OrderId);
            }

            var line = new OrderLine();
            line.ProductName = vm.ProductName;
            line.Qty = vm.Qty;
            line.UnitPrice = products.Single(p => p.Name == vm.ProductName).Price;
            order.AddLine(line);
            vm.OrderId = _db.AddOrUpdateOrder(order);

            // Continuamos agregando lineas a la orden
            vm.Qty = 0;
            vm.ProductName = "";

            return View(vm);
        }
    }
}
