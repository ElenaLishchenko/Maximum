using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/heroes")]
    public class HeroesController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superhero>>> GetAll()
        {
            var heroes = await _context.Superheroes.ToListAsync();
            if (!heroes.Any())
                return NotFound("No heroes found.");

            return Ok(heroes);
        }

        [HttpGet("universe/{name}")]
        public async Task<ActionResult<IEnumerable<Superhero>>> GetByUniverse(string name)
        {
            var heroes = await _context.Superheroes
                                       .Where(h => h.Universe.Name == name)
                                       .ToListAsync();

            if (!heroes.Any())
                return NotFound($"No heroes found for universe {name}.");

            return Ok(heroes);
        }

        [HttpGet("strongest")]
        public async Task<ActionResult<Superhero>> GetStrongest()
        {
            var hero = await _context.Superheroes
                                     .OrderByDescending(h => h.Power)
                                     .FirstOrDefaultAsync();

            if (hero == null)
                return NotFound("No heroes found.");

            return Ok(hero);
        }
    }
}