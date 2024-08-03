namespace DeliveryStoreDomain.Entities {
    public class Product : EntityBase {
        
        public Product() { }

        public Product(string name, int quantity, bool deleted) {
            Id = Guid.NewGuid();
            Name = name;
            Quantity = quantity;
            Deleted = deleted;
        }
        
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public bool Deleted { get; private set; }

        #region Method
        public void Delete() {
            Deleted = true;
        }

        public void Change(string name, int quantity) {
            this.Name = name;
            this.Quantity = quantity;
        }
        #endregion
    }
}
