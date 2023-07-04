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
    public class RacesController : ControllerBase
    {
        private readonly DbConnect _context;

        public RacesController(DbConnect context)
        {
            _context = context;
        }

        // GET: api/Races
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
          if (_context.Races == null)
          {
              return NotFound();
          }

           List<Race> teste = await _context.Races.ToListAsync();

            foreach(Race race in teste)
            {
                race.RaceModifiers = await _context.RacesModifiers
                    .Where(rm => rm.RaceId == race.Id)
                    /*.Join(_context.CadAbilityScore, 
                        cd => cd.Id, 
                        rm => rm.Id, 
                        (rm, cd) => new RaceModifiers {
                            Id= rm.Id,v
                            RaceId= rm.RaceId,
                            //race= null,
                            CadAbilityScoreId= cd.Id,
                            CadAbilityScore= new CadAbilityScore {
                                Name= cd.Name
                            },
                            Value = rm.Value
                        })*/
                    .AsNoTracking().ToListAsync();

                foreach(RaceModifiers raceMd in race.RaceModifiers)
                {
                    raceMd.CadAbilityScore = _context.CadAbilityScore.AsNoTracking().Where(cd => cd.Id == raceMd.CadAbilityScoreId).First();
                }
            }


        return Ok(teste);
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
          if (_context.Races == null)
          {
              return NotFound();
          }
            var race = await _context.Races.FindAsync(id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // PUT: api/Races/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, Race race)
        {
            if (id != race.Id)
            {
                return BadRequest();
            }
            foreach(RaceModifiers raceMd in race.RaceModifiers)
            {
                _context.Entry(raceMd).State = EntityState.Modified;

            }
            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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

        // POST: api/Races
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Race>> PostRace(Race race)
        {
          if (_context.Races == null)
          {
              return Problem("Entity set 'DbConnect.Races'  is null.");
          }

            try
            {
            
            if (race.RaceModifiers != null)
            {
                foreach (var modifier in race.RaceModifiers)
                {
                    modifier.Race = race;
                    _context.RacesModifiers.Add(modifier);
                }
            }
            _context.Races.Add(race);

            await _context.SaveChangesAsync();

            return Ok(race);

            }catch(Exception ex)
            {
                _context.Dispose();
                throw new Exception("Erro ao cadastrar Classe: "+ex.Message);
            }
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            if (_context.Races == null)
            {
                return NotFound();
            }
            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            _context.Races.Remove(race);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(int id)
        {
            return (_context.Races?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
