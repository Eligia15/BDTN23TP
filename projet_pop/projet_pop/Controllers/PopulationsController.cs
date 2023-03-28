using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projet_pop.Data;
using projet_pop.Models;



namespace projef_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationsController : ControllerBase
    {
        private readonly projet_popContext _context;



        public PopulationsController(projet_popContext context)
        {
            _context = context;
        }



        // GET: api/Populations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Population>>> GetPopulation()
        {
            if (_context.Population == null)
            {
                return NotFound();
            }
            return await _context.Population.ToListAsync();
        }



        // GET: api/Populations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Population>> GetPopulation(int id)
        {
            if (_context.Population == null)
            {
                return NotFound();
            }
            var population = await _context.Population.FindAsync(id);



            if (population == null)
            {
                return NotFound();
            }



            return population;
        }



        // PUT: api/Populations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPopulation(int id, Population population)
        {
            if (id != population.Id)
            {
                return BadRequest();
            }



            _context.Entry(population).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PopulationExists(id))
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



        // POST: api/Populations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Population>> PostPopulation(Population population)
        {
            if (_context.Population == null)
            {
                return Problem("Entity set 'projef_2Context.Population'  is null.");
            }
            var pays = await _context.Pays.Include(x => x.populations).FirstOrDefaultAsync(x => x.Id == population.PaysId);
            if (pays == null)
            {
                return BadRequest("Pays not found");
            }
            if (pays.populations == null)
            {
                pays.populations = new List<Population>();
            }
            pays.populations.Add(population);
            _context.Population.Add(population);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetPopulation", new { id = population.Id }, population);
        }



        // DELETE: api/Populations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopulation(int id)
        {
            if (_context.Population == null)
            {
                return NotFound();
            }
            var population = await _context.Population.FindAsync(id);
            if (population == null)
            {
                return NotFound();
            }



            _context.Population.Remove(population);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool PopulationExists(int id)
        {
            return (_context.Population?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}