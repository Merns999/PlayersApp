using Microsoft.AspNetCore.Mvc;
using PlayersApp.Data;
using PlayersApp.Models.Domain;

namespace PlayersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyPlayersController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepo<TEntity>
    {
        private readonly TRepository repository;

        public MyPlayersController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var movie = await repository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TEntity player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }
            await repository.Update(player);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity player)
        {
            await repository.Add(player);
            return CreatedAtAction("Get", new { id = player.Id }, player);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var movie = await repository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

    }
}
