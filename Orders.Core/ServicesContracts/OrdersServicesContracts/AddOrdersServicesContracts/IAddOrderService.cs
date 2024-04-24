using Orders.Core.DTO_s;


namespace Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts
{
    public interface IAddOrderService : IGenericService<OrderRequestDto, OrderResponseDto>
    {
        //Task<OrderResponseDto>AddOrder(OrderRequestDto orderRequestDto);
    }
}
