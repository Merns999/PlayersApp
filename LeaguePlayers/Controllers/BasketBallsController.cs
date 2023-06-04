using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaguePlayers.Data;
using LeaguePlayers.Models.Domain;

namespace LeaguePlayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketBallsController : ControllerBase
    {
        private readonly LeaguePlayersContext _context;

        public BasketBallsController(LeaguePlayersContext context)
        {
            _context = context;
        }

        // GET: api/BasketBalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketBall>>> GetBasketBall()
        {
          if (_context.BasketBall == null)
          {
              return NotFound();
          }
            return await _context.BasketBall.ToListAsync();
        }

        // GET: api/BasketBalls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketBall>> GetBasketBall(Guid id)
        {
          if (_context.BasketBall == null)
          {
              return NotFound();
          }
            var basketBall = await _context.BasketBall.FindAsync(id);

            if (basketBall == null)
            {
                return NotFound();
            }

            return basketBall;
        }

        // PUT: api/BasketBalls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketBall(Guid id, BasketBall basketBall)
        {
            if (id != basketBall.Id)
            {
                return BadRequest();
            }

            _context.Entry(basketBall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketBallExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BasketBalls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasketBall>> PostBasketBall(BasketBall basketBall)
        {
          if (_context.BasketBall == null)
          {
              return Problem("Entity set 'LeaguePlayersContext.BasketBall'  is null.");
          }
            _context.BasketBall.Add(basketBall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketBall", new { id = basketBall.Id }, basketBall);
        }

        // DELETE: api/BasketBalls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketBall(Guid id)
        {
            if (_context.BasketBall == null)
            {
                return NotFound();
            }
            var basketBall = await _context.BasketBall.FindAsync(id);
            if (basketBall == null)
            {
                return NotFound();
            }

            _context.BasketBall.Remove(basketBall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketBallExists(Guid id)
        {
            return (_context.BasketBall?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
