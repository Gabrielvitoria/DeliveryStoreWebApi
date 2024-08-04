using DeliveryStoreCommon.Dtos.Product;
using Entities = DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreServices._1.Interfaces;

namespace DeliveryStoreServices.Product {
    public class ProductService : IProductService {

        public readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto newProductDto) {

            if (newProductDto == null) { throw new NotImplementedException(); }

            try {

                var product = new Entities.Product(newProductDto.Name, newProductDto.Quantity);

                await this.productRepository.CreateAsync(product);

                return new ProductDto { Id = product.Id, Name = product.Name, Quantity = product.Quantity };

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDto> ChangeProductAsync(ChangeProductDto productDto) {

            if (productDto == null) { throw new NotImplementedException(); }

            try {
                var product = await this.productRepository.GetProductByIdAsync(productDto.Id);

                if (product == null) { throw new NotImplementedException(); }

                product.Change(productDto.Name, productDto.Quantity);

                await this.productRepository.UpdateAsync(product);

                return new ProductDto { Id = product.Id, Name = product.Name, Quantity = product.Quantity };
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDto> DeleteProductAsync(Guid productId) {
            if (productId == Guid.Empty) { throw new NotImplementedException(); }

            try {

                var product = await this.productRepository.GetProductByIdAsync(productId);

                product.Delete();

                await this.productRepository.UpdateAsync(product);

                return new ProductDto { Id = product.Id, Name = product.Name, Quantity = product.Quantity, Deleted = product.Deleted };

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync() {

            try {
                var products = await this.productRepository.GetAllAsync();

                var productDtos = new List<ProductDto>();

                foreach (var item in products) {
                    productDtos.Add(new ProductDto { Id = item.Id, Name = item.Name, Quantity = item.Quantity, Deleted = item.Deleted });
                }
                return productDtos;
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }
    }
}
