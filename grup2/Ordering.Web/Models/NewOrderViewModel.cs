using Microsoft.AspNetCore.Mvc.Rendering;
using Ordering.Web.Services;
using System.ComponentModel.DataAnnotations;

namespace Ordering.Web.Models
{
    public class NewOrderViewModel
    {
        // Del controlador a la vista
        public int OrderId { get; set; }
        public IEnumerable<SelectListItem>? Products { get; private set; }
        // De la vista al controlador
        [Range(1, 100)]
        public int Qty { get; set; }
        public string ProductName { get; set; }

        public void SetProductData(IEnumerable<ProductData> products)
        {
            Products = products.Select(pd => new SelectListItem()
            {
                Text = pd.Name,
                Value = pd.Name
            });
        }


    }
}
