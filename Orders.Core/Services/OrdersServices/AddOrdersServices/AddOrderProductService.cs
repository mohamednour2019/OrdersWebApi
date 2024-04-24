using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.AddOrdersServices
{
    public class AddOrderProductService : IAddOrderProductService
    {
        private IOrdersRepository _repository;
        private IGenericRepository<OrderProduct> _orderProductRepository;
        private IGenericRepository<Product> _productRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AddOrderProductService(IOrdersRepository repository,
            IGenericRepository<OrderProduct> orderProductRepository,
            IGenericRepository<Product> productRepository,
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task<ProductDetailsResponseDto> AddProductToOrder(AddOrderProductRequestDto requestDto)
        //{


        //}

        public async Task<ProductDetailsResponseDto> performService(AddOrderProductRequestDto requestDto)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                Order order = await _repository.getOrderById(requestDto.orderId);
                if (order is null || order.OrderProduct.FirstOrDefault(x => x.ProductId == requestDto.ProductId) is not null)
                    throw new Exception("can't add item");



                Product product = await _productRepository.GetAsync(requestDto.ProductId);

                OrderProduct orderProduct = _mapper.Map<OrderProduct>(requestDto);
                orderProduct.OrderId = requestDto.orderId;
                orderProduct.TotalPrice = product.UnitPrice * orderProduct.Quantity;

                order.OrderProduct.Add(orderProduct);
                order.TotalAmount += orderProduct.TotalPrice;
                await _unitOfWork.CommitTransaciton();

                ProductDetailsResponseDto response = _mapper.Map<ProductDetailsResponseDto>(orderProduct);
                return response;

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                return null;
            }
        }
    }
}
