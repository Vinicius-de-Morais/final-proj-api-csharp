using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_projeto_final;
using api_projeto_final.DataModels;

namespace api_projeto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadSkillsController : ControllerBase
    {
        private readonly DbConnect _context;

        public CadSkillsController(DbConnect context)
        {
            _context = context;
        }

        // GET: api/CadSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadSkill>>> GetCadSkill()
        {
          if (_context.CadSkill == null)
          {
              return NotFound();
          }
            return await _context.CadSkill.ToListAsync();
        }

        // GET: api/CadSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadSkill>> GetCadSkill(int id)
        {
          if (_context.CadSkill == null)
          {
              return NotFound();
          }
            var cadSkill = await _context.CadSkill.FindAsync(id);

            if (cadSkill == null)
            {
                return NotFound();
            }

            return cadSkill;
        }

        // PUT: api/CadSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadSkill(int id, CadSkill cadSkill)
        {
            if (id != cadSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadSkillExists(id))
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

        // POST: api/CadSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadSkill>> PostCadSkill(CadSkill cadSkill)
        {
          if (_context.CadSkill == null)
          {
              return Problem("Entity set 'DbConnect.CadSkill'  is null.");
          }
            _context.CadSkill.Add(cadSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadSkill", new { id = cadSkill.Id }, cadSkill);
        }

        // DELETE: api/CadSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadSkill(int id)
        {
            if (_context.CadSkill == null)
            {
                return NotFound();
            }
            var cadSkill = await _context.CadSkill.FindAsync(id);
            if (cadSkill == null)
            {
                return NotFound();
            }

            _context.CadSkill.Remove(cadSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadSkillExists(int id)
        {
            return (_context.CadSkill?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
