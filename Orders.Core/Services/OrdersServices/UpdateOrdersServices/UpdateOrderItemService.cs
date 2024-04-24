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
    public class UpdateOrderItemService : IUpdateOrderItemService
    {
        private IOrdersRepository _repository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UpdateOrderItemService(IOrdersRepository repository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDetailsResponseDto> performService(UpdateOrderItemRequestDto? requestDto)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                Order order = await _repository.getOrderById(requestDto.orderId);
                if (order is null || order.OrderProduct.FirstOrDefault(x => x.ProductId == requestDto.productId) is null)
                    throw new Exception("can't add item");

                OrderProduct orderProduct = order.OrderProduct
                    .FirstOrDefault(x => x.Product.Id == requestDto.productId && x.OrderId == requestDto.orderId);
                double orderUnitPrice = orderProduct.Product.UnitPrice;
                double oldTotalPrice = orderProduct.TotalPrice;
                orderProduct.Quantity = requestDto.Quantity;
                orderProduct.TotalPrice = orderUnitPrice * orderProduct.Quantity;
                orderProduct.Order.TotalAmount += orderProduct.TotalPrice - oldTotalPrice;
                ProductDetailsResponseDto response = _mapper.Map<ProductDetailsResponseDto>(orderProduct);
                await _unitOfWork.CommitTransaciton();
                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                return null;
            }
        }

        //public async Task<ProductDetailsResponseDto> UpdateOrderItem(Guid orderId, Guid productId, UpdateOrderItemRequestDto requestDto)
        //{
        //    try
        //    {
        //        await _unitOfWork.BeginTransaction();

        //        Order order = await _repository.getOrderById(orderId);
        //        if (order is null || order.OrderProduct.FirstOrDefault(x => x.ProductId == productId) is null)
        //            throw new Exception("can't add item");

        //        OrderProduct orderProduct = order.OrderProduct
        //            .FirstOrDefault(x => x.Product.Id == productId && x.OrderId == orderId);
        //        double orderUnitPrice = orderProduct.Product.UnitPrice;
        //        double oldTotalPrice = orderProduct.TotalPrice;
        //        orderProduct.Quantity = requestDto.Quantity;
        //        orderProduct.TotalPrice = orderUnitPrice * orderProduct.Quantity;
        //        orderProduct.Order.TotalAmount += (orderProduct.TotalPrice - oldTotalPrice);
        //        ProductDetailsResponseDto response= _mapper.Map<ProductDetailsResponseDto>(orderProduct);
        //        await _unitOfWork.CommitTransaciton();
        //        return response;
        //    }catch(Exception ex)
        //    {
        //        await _unitOfWork.RollbackTransaction();
        //        return null;
        //    }


        //}
    }
}
