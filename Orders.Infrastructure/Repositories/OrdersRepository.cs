using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Infrastructure.DatabaseContext;


namespace Orders.Infrastructure.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        private ApplicationDbContext _context;
        public OrdersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> getOrders()
        {
           return await _context.Orders.Include(x=>x.OrderProduct).ThenInclude(x=>x.Product).ToListAsync();
        }

        public async Task<Order>? getOrderById(Guid id) 
        {
            //Order order = await _context.Orders.FindAsync(id);
            //if(order is not null)
            //{
            //    var query=_context.Entry(order).Collection(x=>x.OrderProduct).Query();
            //    List<OrderProduct> orderProduct=await query.Include(x=>x.Product).ToListAsync();
            //    order.OrderProduct = orderProduct;
            //    return order;
            //}
           Order order = await _context.Orders
                .Include(x => x.OrderProduct)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (order is null)
                return null;

            return order;
        }

        public async Task<Order>updateOrder(Guid id, UpdateOrderRequestDto updateOrderRequestDto)
        {
            Order ? order = await getOrderById(id);
            if (order is null)
                return null;
            order.CustomerName = updateOrderRequestDto.OrderName;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderProduct?> getOrderProduct(Guid orderId, Guid productId)
        {
            OrderProduct result= await _context.OrderProduct?
                .Include(x => x.Product)?.Include(x=>x.Order)?
                .FirstOrDefaultAsync(x=>x.ProductId == productId&&x.OrderId==orderId)!;
            if(result is null)
                return null;
            return result;
        }
    }
}
