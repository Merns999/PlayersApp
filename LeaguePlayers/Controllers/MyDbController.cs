using LeaguePlayers.Models.Domain;
using LeaguePlayers.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LeaguePlayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDbController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyDbController(TRepository repository)
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
            var player = await repository.Delete(id);
            if (player == null)
            {
                return NotFound();
            }
            return player;
        }

    }
}
