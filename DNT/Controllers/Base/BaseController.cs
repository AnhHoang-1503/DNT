using DNT.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNT.Controllers.Base
{
    public abstract class BaseController<TEntity> : ControllerBase
    {
        private readonly BaseService<TEntity> _baseService;

        protected BaseController(BaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _baseService.GetAll();

            return StatusCode(StatusCodes.Status200OK, entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _baseService.GetById(id);

            return StatusCode(StatusCodes.Status200OK, entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntity entity)
        {
            await _baseService.Create(entity);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TEntity entity)
        {
            await _baseService.Update(id, entity);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _baseService.Delete(id);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMany([FromBody] List<Guid> ids)
        {
            await _baseService.DeleteMany(ids);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
