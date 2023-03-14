using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BaseController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        protected readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _service;

        public BaseController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<ActionResult<TReadDto?>> CreateOne(TCreateDto create)
        {
            var result = await _service.CreateOneAsync(create);
            return CreatedAtAction("Created", result);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryParams options)
        {
            return Ok(await _service.GetAllAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TReadDto?>> GetById([FromRoute] string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        
    }
}
