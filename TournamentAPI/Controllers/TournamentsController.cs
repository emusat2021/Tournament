using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentData.Data;
using TournamentCore.Entities;
using System.Text.Json.Serialization;

namespace TournamentAPI.Controllers
{
    [ApiController]
    [Route("api/tournaments")]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentAPIContext _context;

        public TournamentsController(TournamentAPIContext context)
        {
            _context = context;
        }

        // GET: api/tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }
            //return await _context.Tournament.Include(t => t.Games) // Eager loading of Games
            // .ToListAsync();
            var tournaments = await _context.Tournament
                   .Include(t => t.Games)
                   .Select(t => new Tournament
                   {
                       Id = t.Id,
                       Title = t.Title,
                       StartDate = t.StartDate,
                       Games = t.Games.Select(g => new Game
                       {
                           Id = g.Id,
                           Title = g.Title,
                           Time = g.Time
                       }).ToList()
                   })
                   .ToListAsync();
            return Ok(tournaments);
        }

        // GET: api/tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournamentById(int id)
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }

            //var tournament = await _context.Tournament.Include(g => g.Games).FirstOrDefaultAsync(i => i.Id == id);
            var tournament = await _context.Tournament
                                       .Include(t => t.Games)
                                       .Where(t => t.Id == id)
                                       .Select(t => new Tournament
                                       {
                                           Id = t.Id,
                                           Title = t.Title,
                                           StartDate = t.StartDate,
                                           Games = t.Games.Select(g => new Game
                                           {
                                               Id = g.Id,
                                               Title = g.Title,
                                               Time = g.Time
                                           }).ToList()
                                       })
                                       .FirstOrDefaultAsync();
            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // POST: api/tournament
        [HttpPost]
        public async Task<ActionResult<Tournament>> Create(Tournament tournament)
        {
            _context.Tournament.Add(tournament);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTournamentById), new { id = tournament.Id }, tournament);

        }

        // PUT api/tournament
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTournament(int id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }
            _context.Entry(tournament).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }
            return NoContent();
        }

        //DELETE: api/tournament
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tournament>> DeleteTournament(int id)
        {
            if(_context.Tournament == null)
            {
                return NotFound();
            }
            var tournament = await _context.Tournament.FindAsync(id);
            if(tournament == null)
            {
                return NotFound();
            }
            _context.Tournament.Remove(tournament);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.Id == id);
        }
    }
}
