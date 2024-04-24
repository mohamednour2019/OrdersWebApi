using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts;


namespace Orders.Core.Services.OrdersServices.GetOrdersServices
{
    public class GetOrdersService : IGetOrdersService
    {
        private IOrdersRepository _repository;
        private IMapper _mapper;
        public GetOrdersService(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //public async Task<List<OrderResponseDto>> GetOrdersAsync()
        //{
        //    List<Order>orders=await _repository.getOrders();
        //    List<OrderResponseDto>response= _mapper.Map<List<OrderResponseDto>>(orders);
        //    for(int i=0;i<orders.Count();i++)
        //    {
        //        response[i].ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(orders[i].OrderProduct);
        //    }
        //    return response;
        //}

        public async Task<List<OrderResponseDto>> performService(OrderRequestDto? requestDto)
        {
            List<Order> orders = await _repository.getOrders();
            List<OrderResponseDto> response = _mapper.Map<List<OrderResponseDto>>(orders);
            for (int i = 0; i < orders.Count(); i++)
            {
                response[i].ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(orders[i].OrderProduct);
            }
            return response;
        }
    }
}
