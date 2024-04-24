using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.GetOrdersServices
{
    public class GetOrderItemsService : IGetOrderItemsService
    {
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;
        public GetOrderItemsService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
        }
        //public async Task<List<ProductDetailsResponseDto>?> GetOrderItems(Guid orderId)
        //{
        //   Order? order=await _ordersRepository.getOrderById(orderId);
        //    if (order is null)
        //        return null;
        //    List<ProductDetailsResponseDto> result = _mapper.
        //        Map<List<ProductDetailsResponseDto>>(order.OrderProduct);
        //    return result;
        //}

        public async Task<List<ProductDetailsResponseDto>> performService(Guid orderId)
        {
            Order? order = await _ordersRepository.getOrderById(orderId);
            if (order is null)
                return null;
            List<ProductDetailsResponseDto> result = _mapper.
                Map<List<ProductDetailsResponseDto>>(order.OrderProduct);
            return result;
        }
    }
}
