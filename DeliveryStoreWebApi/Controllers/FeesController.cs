using DeliveryStoreServices.Interfaces;
using DeliveryStoreServices.Product;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryStoreWebApi.Controllers {   
    
    
    [ApiController]
    [ApiVersion("1.0")]
    public class FeesController : ControllerBase {

        private readonly IShippingCalculationService _shippingCalculationService;

        public FeesController(IShippingCalculationService shippingCalculationService)
        {
            _shippingCalculationService = shippingCalculationService;
        }

        // GET: api/<FeesController>
        [Route("api/v1/ShippingCost")]
        [HttpGet]
        public async Task<IActionResult> GetShippingCost([FromQuery] string zipCode) {

            try {
                return Ok(await this._shippingCalculationService.GetShippingCostAsync(zipCode));
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }       
    }
}
