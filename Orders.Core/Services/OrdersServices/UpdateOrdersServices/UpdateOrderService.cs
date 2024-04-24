using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.UpdateOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.UpdateOrdersServices
{
    public class UpdateOrderService : IUpdateOrderService
    {
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;
        public UpdateOrderService(IOrdersRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _ordersRepository = repository;
        }

        public async Task<OrderResponseDto> performService(UpdateOrderRequestDto? updateOrderRequestDto)
        {
            Order? response = await _ordersRepository.updateOrder(updateOrderRequestDto.Id, updateOrderRequestDto);
            if (response is null)
                return null;
            OrderResponseDto orderResponseDto = _mapper.Map<OrderResponseDto>(response);
            orderResponseDto.ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(response.OrderProduct);
            return orderResponseDto;
        }

        //public async Task<OrderResponseDto?> UpdateOrder(UpdateOrderRequestDto updateOrderRequestDto)
        //{
        //    Order ?response= await _ordersRepository.updateOrder(updateOrderRequestDto.Id, updateOrderRequestDto);
        //    if (response is null)
        //        return null;
        //    OrderResponseDto orderResponseDto=_mapper.Map<OrderResponseDto>(response);
        //    orderResponseDto.ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(response.OrderProduct);
        //    return orderResponseDto;
        //}
    }
}
