﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtudePop.Data;
using EtudePop.Models;

namespace EtudePop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly EtudePopContext _context;

        public PaysController(EtudePopContext context)
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
            return await _context.Pays.ToListAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pays>> GetPays(int id)
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

            return pays;
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
              return Problem("Entity set 'EtudePopContext.Pays'  is null.");
          }
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
