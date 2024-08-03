using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryStoreWebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase {

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }
    }
}
