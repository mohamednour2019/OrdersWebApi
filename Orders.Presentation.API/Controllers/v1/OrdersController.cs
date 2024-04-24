using Microsoft.AspNetCore.Mvc;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.UpdateOrdersServicesContracts;



namespace Orders.Presentation.API.Controllers.v1
{

    [Asp.Versioning.ApiVersion("1.0")]
    public class OrdersController : BaseController
    {
        public OrdersController(ILogger<OrdersController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequestDto requestDto
            , [FromServices] IAddOrderService addService)
            => await _presenter.Handle(requestDto, addService);


        /// <summary>
        /// to get list of the orders with it's details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromServices] IGetOrdersService getOrdersService)
            => await _presenter.Handle(null, getOrdersService);


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(Guid id
            , [FromServices] IGetOrderByIdService getOrderByIdService)
             => await _presenter.Handle(id, getOrderByIdService);


        [HttpPut("{id}")]
        public async Task<IActionResult> GetOrders(Guid id, UpdateOrderRequestDto updateItem
            , [FromServices] IUpdateOrderService udateOrderService)
        {
            updateItem.Id = id;
            return await _presenter.Handle(updateItem, udateOrderService);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id
            , [FromServices] IDeleteOrderService deleteOrderService)
            => await _presenter.Handle(id, deleteOrderService);




        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetOrderItems(Guid id
            , [FromServices] IGetOrderItemsService getOrderItemsService)
        => await _presenter.Handle(id, getOrderItemsService);




        [HttpGet("{orderId}/items/{id}")]
        public async Task<IActionResult> GetOrderItems(Guid orderId, Guid id
            , GetOrderItemsRequestDto requestDto
            , [FromServices] IGetOrderItemService getOrderItemService)
        {
            requestDto.orderId = orderId;
            requestDto.productId = id;
            return await _presenter.Handle(requestDto, getOrderItemService);
        }



        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItemToOrder(Guid orderId, AddOrderProductRequestDto requestDto
            , [FromServices] IAddOrderProductService addOrderProductService)
        {
            requestDto.orderId = orderId;
            return await _presenter.Handle(requestDto, addOrderProductService);
        }



        [HttpPut("{orderId}/items/{id}")]
        public async Task<IActionResult> AddItemToOrder(Guid orderId, Guid id, UpdateOrderItemRequestDto requestDto
            , [FromServices] IUpdateOrderItemService updateOrderItemService)
        {
            requestDto.orderId = orderId;
            requestDto.productId = id;
            return await _presenter.Handle(requestDto, updateOrderItemService);
        }



        [HttpDelete("{orderId}/items/{id}")]
        public async Task<IActionResult> DeleteItemFromOrder(Guid orderId, Guid id
            , DeleteOrderItemRequestDto requestDto
            , [FromServices] IDeleteOrderItemService deleteOrderItemService)
        {
            requestDto.OrderId = orderId;
            requestDto.ProductId = id;
            return await _presenter.Handle(requestDto, deleteOrderItemService);
        }

    }
}
