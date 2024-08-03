using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryStoreWebApi.Controllers {
    
    
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FeesController : ControllerBase {
        // GET: api/<FeesController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
       
    }
}
