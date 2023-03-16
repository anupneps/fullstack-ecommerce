using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;
using backend.src.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]s")]
    public class BaseController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        protected readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _service;
       
        public BaseController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TReadDto?>> CreateOne(TCreateDto create)
        {
            var result = await _service.CreateOneAsync(create);
            //return CreatedAtAction("Created", result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryParams options)
        {
            return Ok(await _service.GetAllAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TReadDto?>> GetById([FromRoute] Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        
    }
}
