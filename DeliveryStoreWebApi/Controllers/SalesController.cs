using DeliveryStoreCommon.Dtos.Product;
using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain;
using DeliveryStoreServices.Interfaces;
using DeliveryStoreServices.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryStoreWebApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SalesController : ControllerBase {

        private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService) {
            _saleService = saleService;
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSaleDto createSaleDto) {
            try {
                return Ok(await _saleService.CreateSaleAsync(createSaleDto));
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

        // POST api/<ProductController>
        [Route("Cancel")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] Guid saleId) {
            try {
                await _saleService.CancelSaleAsync(saleId);
                return Ok();
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IActionResult> Get(string? codeOrder = null, SaleStatusEnum? status = null) {
            try {
                return Ok(await _saleService.GetAllSaleAsync(codeOrder, status));
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

        // GET: api/<SalesController>
        [Route("SalesProductItens")]
        [HttpGet]
        public async Task<IActionResult> GetAllSalesProductItensAsync(Guid saleId) {
            try {
                return Ok(await _saleService.GetAllSalesProductItensAsync(saleId));
            }
            catch (Exception ex) {

                return NotFound(ex.Message);
            }
        }

    }
}
