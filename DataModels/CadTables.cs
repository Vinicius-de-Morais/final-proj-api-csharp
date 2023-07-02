using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_projeto_final.DataModels
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RaceModifiers>? RaceModifiers { get; set; }
    }

    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ClassModifiers>? ClassModifiers { get; set; }
    }

    public class ClassModifiers
    {
        [Key]
        public int Id { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }
        public int? CadAbilityScoreId { get; set; }
        [ForeignKey("CadAbilityScoreId")]
        public CadAbilityScore? CadAbilityScore { get; set; }

        public int Value { get; set; }
    }

    public class RaceModifiers
    {
        [Key]
        public int Id { get; set; }
        public int? RaceId { get; set; }
        [ForeignKey("RaceId")]
        public Race? Race { get; set; }
        public int? CadAbilityScoreId { get; set; }
        [ForeignKey("CadAbilityScoreId")]
        public CadAbilityScore? CadAbilityScore { get; set; }
        public int Value { get; set; }
    }

    public class CadAbilityScore
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CharacterAbilityScore>? CharacterAbilityScore { get; set; }
        public List<ClassModifiers>? ClassModifiers { get; set; }
        public List<RaceModifiers>? RaceModifiers { get; set; }
    }

    public class CadSkill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CharacterSkill> characterSkills { get; set; }
    }

    public class CadSpell
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CharacterSpell> characterSpells { get; set; }

    }
}