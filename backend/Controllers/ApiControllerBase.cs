using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
