using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentData.Data;
using TournamentCore.Entities;

namespace TournamentAPI.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly TournamentAPIContext _context;

        public GamesController(TournamentAPIContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            if(_context.Game == null)
            {
                return NotFound();
            }
            return await _context.Game.ToListAsync();
        }

        // GET: api/Games//5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int? id)
        {
            if (_context.Game == null)
            {
                return NotFound();
            }
            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // POST: api/game
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
                _context.Game.Add(game);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetGameById), new {id = game.Id}, game);
        }

        // PUT api/game
        [HttpPut("{id}")]
        public async Task<IActionResult> EditGame(int id, Game game)
        {
            if(id !=game.Id)
            {
                return BadRequest();
            }
            _context.Entry(game).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!GameExists(id))
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

        // Delete: api/game
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            if (_context.Game == null)
            {
                return NotFound();
            }
            var game = await _context.Game.FindAsync(id);
            if(game == null)
            {
                return NotFound();
            }
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
