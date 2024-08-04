using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface ISalesRepository {

        public IEnumerable<Sale> GetAllAsync();
        public Sale CreateAsync(Sale product);
        public Sale UpdateAsync(Sale product);
    }
}
