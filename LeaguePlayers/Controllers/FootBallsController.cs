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
    public class FootBallsController : ControllerBase
    {
        private readonly LeaguePlayersDbContext _context;

        public FootBallsController(LeaguePlayersDbContext context)
        {
            _context = context;
        }

        // GET: api/FootBalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FootBall>>> GetFootBall()
        {
          if (_context.FootBall == null)
          {
              return NotFound();
          }
            return await _context.FootBall.ToListAsync();
        }

        // GET: api/FootBalls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FootBall>> GetFootBall(Guid id)
        {
          if (_context.FootBall == null)
          {
              return NotFound();
          }
            var footBall = await _context.FootBall.FindAsync(id);

            if (footBall == null)
            {
                return NotFound();
            }

            return footBall;
        }

        // PUT: api/FootBalls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootBall(Guid id, FootBall footBall)
        {
            if (id != footBall.Id)
            {
                return BadRequest();
            }

            _context.Entry(footBall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootBallExists(id))
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

        // POST: api/FootBalls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FootBall>> PostFootBall(FootBall footBall)
        {
          if (_context.FootBall == null)
          {
              return Problem("Entity set 'LeaguePlayersContext.FootBall'  is null.");
          }
            _context.FootBall.Add(footBall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFootBall", new { id = footBall.Id }, footBall);
        }

        // DELETE: api/FootBalls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootBall(Guid id)
        {
            if (_context.FootBall == null)
            {
                return NotFound();
            }
            var footBall = await _context.FootBall.FindAsync(id);
            if (footBall == null)
            {
                return NotFound();
            }

            _context.FootBall.Remove(footBall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootBallExists(Guid id)
        {
            return (_context.FootBall?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
