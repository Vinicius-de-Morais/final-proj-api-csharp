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
    public class CharactersController : ControllerBase
    {
        private readonly DbConnect _context;

        public CharactersController(DbConnect context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }

           
            List<Character> characterList = await _context.Characters
                .Include(c => c.Race)
                .Include(c => c.Class)
                .ToListAsync();

            return Ok(characterList);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }
            var character = await _context.Characters
                .Include(c => c.Race)
                .Include(c => c.Class)
                .Include(c => c.AbilityScore)
                    .ThenInclude(cas => cas.CadAbilityScore)
                .Include(c => c.Skills)
                    .ThenInclude(cs => cs.CadSkill)
                .Include(c => c.Spells)
                    .ThenInclude(css => css.CadSpell)
                .Include(c => c.Equipment)
                .FirstOrDefaultAsync(c => c.Id == id); ;

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            foreach (CharacterAbilityScore abilityScore in character.AbilityScore)
            {
                abilityScore.CharacterId = character.Id;
                _context.Entry(abilityScore).State = EntityState.Modified;
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
          if (_context.Characters == null)
          {
              return Problem("Entity set 'DbConnect.Characters'  is null.");
          }
            

            if (character.Skills != null)
            {
                foreach(CharacterSkill skill in character.Skills)
                {
                    skill.Character = character;
                    //_context.CharacterSkills.Add(skill);
                }

            }

          if(character.Spells != null)
            {

                foreach (CharacterSpell spell in character.Spells)
                {
                    spell.Character = character;
                   // _context.CharacterSpells.Add(spell);
                }
            }
           if(character.Equipment != null)
            {

                foreach (Equipment equipment in character.Equipment)
                {
                    equipment.Character = character;
                    //_context.Equipment.Add(equipment);
                }
            }

            List<CadAbilityScore> cadAbilityScores = _context.CadAbilityScore.AsNoTracking().ToList();
            List<ClassModifiers> classModifiers = _context.ClassesModifiers.AsNoTracking().Where(cm => cm.ClassId == character.ClassId).ToList();
            List<RaceModifiers> raceModifiers = _context.RacesModifiers.AsNoTracking().Where(rm => rm.RaceId == character.RaceId).ToList();

            // setar os valores da classe
            List<CharacterAbilityScore> abilities = new List<CharacterAbilityScore>();
            foreach (CadAbilityScore cadAbilityScore in cadAbilityScores)
            {
                CharacterAbilityScore tempAbility = new CharacterAbilityScore();
                tempAbility.Character = character;
                tempAbility.CadAbilityScoreId = cadAbilityScore.Id;
                tempAbility.Value = 0;

                foreach (ClassModifiers classModifier in classModifiers)
                {
                    if (classModifier.CadAbilityScoreId == cadAbilityScore.Id)
                    {
                        tempAbility.Value += classModifier.Value;
                        break;
                    }
                }

                foreach (RaceModifiers raceModifier in raceModifiers)
                {
                    if (raceModifier.CadAbilityScoreId == cadAbilityScore.Id)
                    {
                        tempAbility.Value += raceModifier.Value;
                        break;
                    }
                }
                _context.CharacterAbilityScores.Add(tempAbility);
            }
            //character.AbilityScore = abilities;

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
