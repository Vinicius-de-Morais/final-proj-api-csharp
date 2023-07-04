using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_projeto_final;
using api_projeto_final.DataModels;
using Microsoft.AspNetCore.Authorization;

namespace api_projeto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "login_token")]
    public class CadSpellsController : ControllerBase
    {
        private readonly DbConnect _context;

        public CadSpellsController(DbConnect context)
        {
            _context = context;
        }

        // GET: api/CadSpells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadSpell>>> GetCadSpell()
        {
          if (_context.CadSpell == null)
          {
              return NotFound();
          }
            return await _context.CadSpell.ToListAsync();
        }

        // GET: api/CadSpells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadSpell>> GetCadSpell(int id)
        {
          if (_context.CadSpell == null)
          {
              return NotFound();
          }
            var cadSpell = await _context.CadSpell.FindAsync(id);

            if (cadSpell == null)
            {
                return NotFound();
            }

            return cadSpell;
        }

        // PUT: api/CadSpells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadSpell(int id, CadSpell cadSpell)
        {
            if (id != cadSpell.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadSpell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadSpellExists(id))
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

        // POST: api/CadSpells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadSpell>> PostCadSpell(CadSpell cadSpell)
        {
          if (_context.CadSpell == null)
          {
              return Problem("Entity set 'DbConnect.CadSpell'  is null.");
          }
            _context.CadSpell.Add(cadSpell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadSpell", new { id = cadSpell.Id }, cadSpell);
        }

        // DELETE: api/CadSpells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadSpell(int id)
        {
            if (_context.CadSpell == null)
            {
                return NotFound();
            }
            var cadSpell = await _context.CadSpell.FindAsync(id);
            if (cadSpell == null)
            {
                return NotFound();
            }

            _context.CadSpell.Remove(cadSpell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadSpellExists(int id)
        {
            return (_context.CadSpell?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
