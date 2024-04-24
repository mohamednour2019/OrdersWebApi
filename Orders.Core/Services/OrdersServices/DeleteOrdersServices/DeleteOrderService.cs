using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.DeleteOrdersServices
{
    public class DeleteOrderService : IDeleteOrderService
    {
        private IGenericRepository<Order> _repository;
        public DeleteOrderService(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }
        //public async Task<bool> DeleteOrder(Guid id)
        //{
        //   bool result= await _repository.Delete(id);
        //   return result;   
        //}

        public async Task<bool> performService(Guid orderId)
        {
            bool result = await _repository.Delete(orderId);
            return result;
        }
    }
}
