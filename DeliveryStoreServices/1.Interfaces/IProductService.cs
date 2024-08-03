using DeliveryStoreCommon.Dtos.Product;

namespace DeliveryStoreServices._1.Interfaces {
    public interface IProductService {

        public ProductDto GetAllProductAsync();
        public ProductDto CreateProductAsync(ProductDto newProduct);
        public ProductDto ChangeProductAsync(ChangeProductDto newProduct);
        public ProductDto DeleteProductAsync(Guid productId);        
    }
}
