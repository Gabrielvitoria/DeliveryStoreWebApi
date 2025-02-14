﻿using DeliveryStoreCommon.Dtos.Product;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreServices.Interfaces;

namespace DeliveryStoreServices.Product {
    public class ProductService : IProductService {

        private readonly IProductRepository _repository;
        public ProductService(IProductRepository productRepository) {
            _repository = productRepository;
        }

        public async Task<ProductDto> ChangeProductAsync(Guid productId, ChangeProductDto productDto) {

            if (productDto == null) { throw new Exception("ERRO: product not found or invalid"); }

            try {
                var product = await this._repository.GetProductByIdAsync(productId);

                if (product == null) { throw new Exception("ERRO: product not found or invalid"); }

                product.Change(productDto.Name, productDto.Quantity);

                await this._repository.UpdateAsync(product);

                return new ProductDto { Id = new Guid(product.Id), Name = product.Name, Quantity = product.Quantity };
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto newProductDto) {

            if (newProductDto == null) { throw new Exception("ERRO: new product invalid"); }

            if (newProductDto.Quantity == 0) { throw new Exception("ERRO: The quantity of this product cannot be equal to zero"); }

            try {

                var product = new DeliveryStoreDomain.Entities.Product(newProductDto.Name, newProductDto.Quantity);

                await this._repository.CreateAsync(product);

                return new ProductDto { Id = new Guid(product.Id), Name = product.Name, Quantity = product.Quantity };

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync(Guid? id = null, string? name = null, bool? showDeleted = null) {

            try {
                var products = await this._repository.GetAllAsync(id, name, showDeleted);

                var productDtos = new List<ProductDto>();

                foreach (var item in products) {
                    productDtos.Add(new ProductDto { Id = new Guid(item.Id), Name = item.Name, Quantity = item.Quantity, Deleted = item.Deleted });
                }
                return productDtos;
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDto> DeleteProductAsync(Guid productId) {
            if (productId == Guid.Empty) { throw new NotImplementedException(); }

            try {

                var product = await this._repository.GetProductByIdAsync(productId);

                if (product == null) { throw new NotImplementedException(); }

                product.Delete();

                await this._repository.DeleteAsync(product);

                return new ProductDto { Id = new Guid(product.Id), Name = product.Name, Quantity = product.Quantity, Deleted = product.Deleted };

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }
    }
}
