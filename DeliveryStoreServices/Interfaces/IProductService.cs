using DeliveryStoreCommon.Dtos.Product;

namespace DeliveryStoreServices.Interfaces {
    public interface IProductService {

        Task<IEnumerable<ProductDto>> GetAllProductAsync(int? deleted = null);
        Task<ProductDto> CreateProductAsync(CreateProductDto newProductDto);
        Task<ProductDto> ChangeProductAsync(ChangeProductDto newProductDto);
        Task<ProductDto> DeleteProductAsync(Guid productId);
    }
}
