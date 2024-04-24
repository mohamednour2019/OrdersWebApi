using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.Extensions;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;
using SharedHelpers.EntitiesValidationHelpers;
using System.Diagnostics.Metrics;

namespace Orders.Core.Services.OrdersServices.AddOrdersServices
{
    public class AddOrderService : IAddOrderService
    {
        private IGenericRepository<Order> _ordersRepository;
        private IGenericRepository<Product> _productsRepository;
        private IGenericRepository<OrderProduct> _orderProductRepository;
        private OrderResponseDto _orderResponseDto;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AddOrderService(IGenericRepository<Order> ordersRepository
            , IGenericRepository<Product> productRepository,
            IGenericRepository<OrderProduct> orderProductRepository,
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productRepository;
            _orderProductRepository = orderProductRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Order generateOrder(OrderRequestDto orderRequestDto)
        {
            return new Order()
            {
                CustomerName = orderRequestDto.CustomerName,
                OrderDate = DateTime.Now,
                OrderNumber = $"{DateTime.Now.Year}_{DateTime.Now.Minute}_{DateTime.Now.Second}",
                Id = Guid.NewGuid(),
                TotalAmount = 0
            };
        }

        public async Task<OrderResponseDto> performService(OrderRequestDto orderRequestDto)
        {
            //validate requestDto properties
            EntityValidation.ModelValidation(orderRequestDto);
            try
            {
                //create order object to use in db
                Order order = generateOrder(orderRequestDto);

                //begin transaction
                await _unitOfWork.BeginTransaction();

                //insert order to db
                await _ordersRepository.InsertAsync(order);

                //get order items id's
                var productsIds = orderRequestDto.ProductsDetails.Select(x => x.Id).ToList();

                //get prodcuts objects from database
                List<Product> products = await _productsRepository.GetByCondition(x => productsIds.Contains(x.Id));

                List<ProductDetailsResponseDto> productsDetailsResponseDtos = new List<ProductDetailsResponseDto>();
                List<OrderProduct> ordersProducts = new List<OrderProduct>();

                //looping for calculate price of each product and generate appropriate response
                for (int i = 0; i < orderRequestDto.ProductsDetails.Count(); i++)
                {
                    ProductDetailsResponseDto productDetailsResponseDto = _mapper.Map<ProductDetailsResponseDto>((products[i], orderRequestDto.ProductsDetails[i]));
                    productDetailsResponseDto.TotalPrice = productDetailsResponseDto.UnitPrice * productDetailsResponseDto.Quantity;
                    productsDetailsResponseDtos.Add(productDetailsResponseDto);
                    order.TotalAmount += productDetailsResponseDto.TotalPrice;
                    OrderProduct orderProduct = _mapper.Map<OrderProduct>((orderRequestDto.ProductsDetails[i], order, productDetailsResponseDto));
                    ordersProducts.Add(orderProduct);
                }

                //insert order items
                await _orderProductRepository.InsertRangeAsync(ordersProducts);

                //commit transaction
                await _unitOfWork.CommitTransaciton();

                _orderResponseDto = _mapper.Map<OrderResponseDto>(order);
                _orderResponseDto.ProductsDetails = productsDetailsResponseDtos;
                return _orderResponseDto;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }







        //public async Task<OrderResponseDto> AddOrder(OrderRequestDto orderRequestDto)
        //{
        //    //validate requestDto properties
        //    EntityValidation.ModelValidation(orderRequestDto);
        //    try
        //    {
        //        //create order object to use in db
        //        Order order = generateOrder(orderRequestDto);

        //        //begin transaction
        //        await _unitOfWork.BeginTransaction();

        //        //insert order to db
        //        await _ordersRepository.InsertAsync(order);

        //        //get order items id's
        //        var productsIds=orderRequestDto.ProductsDetails.Select(x => x.Id).ToList();

        //        //get prodcuts objects from database
        //        List<Product> products =await _productsRepository.GetByCondition(x => productsIds.Contains(x.Id));

        //        List<ProductDetailsResponseDto> productsDetailsResponseDtos = new List<ProductDetailsResponseDto>();
        //        List<OrderProduct> ordersProducts = new List<OrderProduct>();

        //        //looping for calculate price of each product and generate appropriate response
        //        for(int i=0;i<orderRequestDto.ProductsDetails.Count();i++)
        //        {
        //            ProductDetailsResponseDto productDetailsResponseDto = _mapper.Map<ProductDetailsResponseDto>((products[i], orderRequestDto.ProductsDetails[i]));
        //            productDetailsResponseDto.TotalPrice = productDetailsResponseDto.UnitPrice * productDetailsResponseDto.Quantity;
        //            productsDetailsResponseDtos.Add(productDetailsResponseDto);
        //            order.TotalAmount += productDetailsResponseDto.TotalPrice;
        //            OrderProduct orderProduct = _mapper.Map<OrderProduct>((orderRequestDto.ProductsDetails[i], order, productDetailsResponseDto));
        //            ordersProducts.Add(orderProduct);
        //        }

        //        //insert order items
        //        await _orderProductRepository.InsertRangeAsync(ordersProducts);

        //        //commit transaction
        //        await _unitOfWork.CommitTransaciton();

        //        _orderResponseDto = _mapper.Map<OrderResponseDto>(order);
        //        _orderResponseDto.ProductsDetails = productsDetailsResponseDtos;
        //        return _orderResponseDto;
        //    }
        //    catch(Exception ex)
        //    { 
        //        await _unitOfWork.RollbackTransaction();
        //        throw;
        //    }

        //}


    }
}
