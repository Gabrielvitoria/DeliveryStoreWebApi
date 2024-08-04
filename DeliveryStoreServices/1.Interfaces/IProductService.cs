using DeliveryStoreCommon.Dtos.Product;

namespace DeliveryStoreServices._1.Interfaces {
    public interface IProductService {

        public Task<IEnumerable<ProductDto>> GetAllProductAsync();
        public Task<ProductDto> CreateProductAsync(CreateProductDto newProductDto);
        public Task<ProductDto> ChangeProductAsync(ChangeProductDto newProductDto);
        public Task<ProductDto> DeleteProductAsync(Guid productId);        
    }
}
