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
    public class CadAbilityScoresController : ControllerBase
    {
        private readonly DbConnect _context;

        public CadAbilityScoresController(DbConnect context)
        {
            _context = context;
        }

        // GET: api/CadAbilityScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadAbilityScore>>> GetCadAbilityScore()
        {
          if (_context.CadAbilityScore == null)
          {
              return NotFound();
          }
            return await _context.CadAbilityScore.ToListAsync();
        }

        // GET: api/CadAbilityScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadAbilityScore>> GetCadAbilityScore(int id)
        {
          if (_context.CadAbilityScore == null)
          {
              return NotFound();
          }
            var cadAbilityScore = await _context.CadAbilityScore.FindAsync(id);

            if (cadAbilityScore == null)
            {
                return NotFound();
            }

            return cadAbilityScore;
        }

        // PUT: api/CadAbilityScores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadAbilityScore(int id, CadAbilityScore cadAbilityScore)
        {
            if (id != cadAbilityScore.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadAbilityScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadAbilityScoreExists(id))
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

        // POST: api/CadAbilityScores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadAbilityScore>> PostCadAbilityScore(CadAbilityScore cadAbilityScore)
        {
          if (_context.CadAbilityScore == null)
          {
              return Problem("Entity set 'DbConnect.CadAbilityScore'  is null.");
          }
            _context.CadAbilityScore.Add(cadAbilityScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadAbilityScore", new { id = cadAbilityScore.Id }, cadAbilityScore);
        }

        // DELETE: api/CadAbilityScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadAbilityScore(int id)
        {
            if (_context.CadAbilityScore == null)
            {
                return NotFound();
            }
            var cadAbilityScore = await _context.CadAbilityScore.FindAsync(id);
            if (cadAbilityScore == null)
            {
                return NotFound();
            }

            _context.CadAbilityScore.Remove(cadAbilityScore);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CadAbilityScoreExists(int id)
        {
            return (_context.CadAbilityScore?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
