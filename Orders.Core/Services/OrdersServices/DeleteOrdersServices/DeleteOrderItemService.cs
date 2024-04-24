using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.DeleteOrdersServices
{
    public class DeleteOrderItemService : IDeleteOrderItemService
    {
        private IOrdersRepository _repository;
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Order> _orderRepository;
        public DeleteOrderItemService(IOrdersRepository repository
            , IGenericRepository<Order> orderRepository
            , IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        //public async Task<bool> DeleteOrderItem(Guid orderId, Guid productId)
        //{
        //    try
        //    {
        //        await _unitOfWork.BeginTransaction();

        //        Order order = await _repository.getOrderById(orderId);
        //        if (order is null || order.OrderProduct.FirstOrDefault(x => x.ProductId == productId) is null)
        //            throw new Exception("can't add item");
        //        OrderProduct orderProduct=order.OrderProduct
        //            .FirstOrDefault(x=>x.OrderId == orderId&&x.ProductId==productId);

        //        if (order.OrderProduct.Count() == 1)
        //        { 
        //            await _orderRepository.Delete(orderId); 
        //        }
        //        else
        //        {
        //            double totalPrice = orderProduct.TotalPrice;
        //            order.OrderProduct.Remove(orderProduct);
        //            order.TotalAmount -= totalPrice;
        //        }
        //        await _unitOfWork.CommitTransaciton();
        //        return true;    


        //    }catch(Exception ex) {
        //        await _unitOfWork.RollbackTransaction();
        //        return false;
        //    }

        //}

        public async Task<bool> performService(DeleteOrderItemRequestDto? requestDto)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                Order order = await _repository.getOrderById(requestDto.OrderId);
                if (order is null || order.OrderProduct.FirstOrDefault(x => x.ProductId == requestDto.ProductId) is null)
                    throw new Exception("can't add item");
                OrderProduct orderProduct = order.OrderProduct
                    .FirstOrDefault(x => x.OrderId == requestDto.OrderId && x.ProductId == requestDto.ProductId);

                if (order.OrderProduct.Count() == 1)
                {
                    await _orderRepository.Delete(requestDto.OrderId);
                }
                else
                {
                    double totalPrice = orderProduct.TotalPrice;
                    order.OrderProduct.Remove(orderProduct);
                    order.TotalAmount -= totalPrice;
                }
                await _unitOfWork.CommitTransaciton();
                return true;


            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                return false;
            }
        }
    }
}
