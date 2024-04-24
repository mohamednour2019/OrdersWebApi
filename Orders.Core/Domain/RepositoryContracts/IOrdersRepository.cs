

using Orders.Core.Domain.Entities;
using Orders.Core.DTO_s;

namespace Orders.Core.Domain.RepositoryContracts
{
    public interface IOrdersRepository
    {
        Task<List<Order>> getOrders();
        Task<Order>? getOrderById(Guid id);
        Task<Order> updateOrder(Guid id, UpdateOrderRequestDto updateOrderRequestDto);

        Task<OrderProduct?> getOrderProduct(Guid orderId,Guid productId);
        
    }
}
