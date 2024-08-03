namespace DeliveryStoreDomain.Entities {
    public class EntityBase {

        public Guid Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime? ChangeDate { get; protected set; }
    }
}
