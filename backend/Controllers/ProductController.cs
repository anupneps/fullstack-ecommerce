using backend.Models;

using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{  
    public class ProductController : ApiControllerBase
    {
        [HttpGet]
        public ActionResult<Product> SayHello()
        {
            return Ok(new { Message = "Hello Backend API" });
        }
    }
}
