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
    public class GetOrderItemService : IGetOrderItemService
    {
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;
        public GetOrderItemService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
        }
        //public async Task<ProductDetailsResponseDto> GetOrderItem(Guid orderId, Guid productId)
        //{
        //  OrderProduct result= await _ordersRepository.getOrderProduct(orderId,productId);
        //  ProductDetailsResponseDto response= _mapper.Map<ProductDetailsResponseDto>(result);
        //  return response;
        //}

        public async Task<ProductDetailsResponseDto> performService(GetOrderItemsRequestDto? requestDto)
        {
            OrderProduct result = await _ordersRepository.getOrderProduct(requestDto.orderId, requestDto.productId);
            ProductDetailsResponseDto response = _mapper.Map<ProductDetailsResponseDto>(result);
            return response;
        }
    }
}
