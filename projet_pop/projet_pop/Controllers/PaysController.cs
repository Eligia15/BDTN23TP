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
    public class PaysController : ControllerBase
    {
        private readonly projet_popContext _context;



        public PaysController(projet_popContext context)
        {
            _context = context;
        }



        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pays>>> GetPays()
        {
            if (_context.Pays == null)
            {
                return NotFound();
            }
            return await _context.Pays.Include("populations").ToListAsync();
        }



        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pays>> GetPays(int id)
        {
            if (_context.Pays == null)
            {
                return NotFound();
            }
            var pays = await _context.Pays.Include(p => p.populations).FirstOrDefaultAsync(p => p.Id == id);



            if (pays == null)
            {
                return NotFound();
            }



            return pays;
        }
        // GET: api/Pays/5/population/2022
        [HttpGet("{id}/population/{year}")]
        public async Task<ActionResult<String>> GetPopulationByCountryAndYear(int id, int year)
        {
            if (_context.Pays == null)
            {
                return NotFound();
            }
            int population = 0;
            var countrie = await _context.Pays.Include(c => c.populations).FirstOrDefaultAsync(c => c.Id == id);





            if (countrie == null)
            {
                return NotFound();
            }





            var pop = countrie.populations.FirstOrDefault(p => p.year == year);
            var name = await _context.Pays
            .Where(c => c.Id == id)
            .Select(c => c.Name)
            .FirstOrDefaultAsync();
            var annee = await _context.Population
            .Where(p => p.PaysId == id)
            .Select(p => p.year)
            .FirstOrDefaultAsync();
            if (pop == null)
            {
                return NotFound();
            }
            if (pop != null)
            {
                population += pop.population;
            }





            return String.Concat("La population du pays ", name, " en ", annee, " est de : ", population);
        }



        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPays(int id, Pays pays)
        {
            if (id != pays.Id)
            {
                return BadRequest();
            }



            _context.Entry(pays).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaysExists(id))
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



        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pays>> PostPays(Pays pays)
        {
            if (_context.Pays == null)
            {
                return Problem("Entity set 'projef_2Context.Pays'  is null.");
            }
            var continent = _context.Continent.Include(c => c.pays).FirstOrDefault(c => c.Id == pays.ContinentId);
            if (continent == null)
            {
                return BadRequest("Continent not found");
            }
            if (continent.pays == null)
            {
                continent.pays = new List<Pays>();
            }
            continent.pays.Add(pays);
            _context.Pays.Add(pays);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetPays", new { id = pays.Id }, pays);
        }



        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePays(int id)
        {
            if (_context.Pays == null)
            {
                return NotFound();
            }
            var pays = await _context.Pays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }



            _context.Pays.Remove(pays);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool PaysExists(int id)
        {
            return (_context.Pays?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}