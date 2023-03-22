using backend.src.Repositories.BaseRepo;
using backend.src.Services.BaseService;
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
        public async virtual Task<ActionResult<TReadDto?>> CreateOne(TCreateDto create)
        {
            var result = await _service.CreateOneAsync(create);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryParams options)
        {
            return Ok(await _service.GetAllAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TReadDto?>> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TReadDto>> UpdateOne(int id, TUpdateDto update)
        {
            return Ok(await _service.UpdateOneAsync(id, update));
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TReadDto>> DeleteOne(int id)
        {
            return Ok(await _service.DeleteOneAsync(id));
        }
    }
}
