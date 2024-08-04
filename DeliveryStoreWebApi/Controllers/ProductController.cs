
using DeliveryStoreCommon.Dtos.Product;
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
        public async Task<IActionResult> Get(int? deleted = null) {
            try {
                return Ok(await _productService.GetAllProductAsync(deleted));
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto) {
            try {
                return Ok(await _productService.CreateProductAsync(createProductDto));
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {

            try {
                return Ok(await _productService.DeleteProductAsync(id));
            }
            catch {
                return NotFound();
            }

        }


    }
}
