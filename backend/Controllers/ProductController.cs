using backend.Models;

using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]s")]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        public ActionResult<Product> SayHello()
        {

            return Ok(new { Message = "Hello Backend API" });
        }
    }
}
