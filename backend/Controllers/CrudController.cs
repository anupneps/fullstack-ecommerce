using backend.DTOs;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public abstract class CrudController<TModel, TDto> : ApiControllerBase where TModel : BaseModel where TDto : BaseDTO<TModel>
    {
        protected readonly IcrudServices<TModel, TDto> _services;

        public CrudController(IcrudServices<TModel, TDto> services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpPost]
        public async virtual Task<ActionResult<TModel>> Create(TDto request)
        {
            var item = await _services.CreateAsync(request);
            if (item == null) { return BadRequest() ; }
            return Ok(item);
        }

        [HttpGet]
        public virtual async Task<ICollection<TModel>> GetAll()
        {
            return await _services.GetAllAsync();
        }
       
    }
}
