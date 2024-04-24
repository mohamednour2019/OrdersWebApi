using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;
using SharedHelpers.EntitiesValidationHelpers;


namespace Orders.Core.Services
{
    public class AddProductService : IAddProductService
    {
        private IGenericRepository<Product> _productsRepository;
        private IMapper _mapper;
        public AddProductService(IGenericRepository<Product> productsRepository
            ,IMapper mapper)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

 
        public async Task<ProductResponseDto> performService(ProductRequestDto? productRequestDto)
        {
            //throw new Exception("hello from AddItem");
            EntityValidation.ModelValidation(productRequestDto);
            Product item = _mapper.Map<Product>(productRequestDto);
            item.Id = Guid.NewGuid();
            await _productsRepository.InsertAndSaveChangeAsync(item);
            ProductResponseDto productResponseDto = _mapper.Map<ProductResponseDto>(item);
            return productResponseDto;
        }
    }
}
