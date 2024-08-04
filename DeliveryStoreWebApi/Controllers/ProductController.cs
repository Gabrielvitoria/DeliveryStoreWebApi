
using DeliveryStoreServices.Interfaces;
using DeliveryStoreServices.Product;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryStoreWebApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                return Ok(await _productService.GetAllProductAsync());
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }


    
    }
}
