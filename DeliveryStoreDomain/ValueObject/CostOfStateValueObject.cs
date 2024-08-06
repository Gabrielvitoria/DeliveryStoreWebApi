
namespace DeliveryStoreDomain.ValueObject {

    public class CostOfStateValueObject {
        public string Uf { get; set; } = string.Empty;
        public decimal Cost { get; set; } 
        public string IbgeCode { get; set; } = string.Empty;
        public string localidade { get; set; }

        public static List<CostOfStateValueObject> GetTableOfCost(CompanyValueObject company, ShippingCostValueObject shipping) {

            var tableCost = new List<CostOfStateValueObject>();

            tableCost.Add(new CostOfStateValueObject { IbgeCode = company.Address.ibge,  Uf = company.Address.uf, Cost = shipping.DeliverySameMunicipality });
            tableCost.Add(new CostOfStateValueObject { Uf = company.Address.uf, Cost = shipping.DeliverySameState  });
            tableCost.Add(new CostOfStateValueObject { Cost = shipping.Default });

            return tableCost;
        }
    }
}
