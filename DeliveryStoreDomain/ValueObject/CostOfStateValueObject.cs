
namespace DeliveryStoreDomain.ValueObject {

    public class CostOfStateValueObject {
        public string Uf { get; set; }
        public string Local { get; set; }
        public decimal Cost { get; set; }


        public static List<CostOfStateValueObject> GetTableOfCost() {

            var tableCost = new List<CostOfStateValueObject>();

            tableCost.Add(new CostOfStateValueObject { Uf = "RJ", Local = "Rio de Janeiro", Cost = 10.00m });
            tableCost.Add(new CostOfStateValueObject { Uf = "RJ", Local = "", Cost = 20.00m });
            tableCost.Add(new CostOfStateValueObject { Uf = "", Local = "",  Cost = 40.00m });

            return tableCost;
        }
    }
}
