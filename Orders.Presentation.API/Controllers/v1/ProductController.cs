using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;

namespace Orders.Presentation.API.Controllers.v1
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<OrdersController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDto item
            , [FromServices] IAddProductService itemService)
            => await _presenter.Handle(item, itemService);
    }
}
