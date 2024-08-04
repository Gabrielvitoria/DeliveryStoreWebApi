namespace DeliveryStoreDomain.Entities {
    public class Product : EntityBase {

        public Product()
        {
            
        }
        public Product(string name, int quantity) {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            Name = name;
            Quantity = quantity;
            Deleted = 0;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Deleted { get; set; }

        #region Method
        public void Delete() {
            Deleted = 1;
        }

        public void Change(string name, int quantity) {
            this.Name = name;
            this.Quantity = quantity;
        }
        #endregion
    }
}
