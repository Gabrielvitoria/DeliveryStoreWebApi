using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryStoreWebApi.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SalesController : ControllerBase {

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }
    }
}
