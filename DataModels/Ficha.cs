using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_projeto_final.DataModels
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public user? User { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        [Column(TypeName = "varchar(256)")]
        public string? Notes { get; set; }
        public int RaceId { get; set; }
        [ForeignKey("RaceId")]
        public Race? Race { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class? Class { get; set; }

        public List<CharacterAbilityScore>? AbilityScore { get; set; }

        public List<CharacterSkill>? Skills { get; set; }
        
        public List<CharacterSpell>? Spells { get; set; }
        
        public List<Equipment>? Equipment { get; set; }
    }

    public class CharacterAbilityScore
    {
        [Key]
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }

        public int? CadAbilityScoreId { get; set; }
        [ForeignKey("CadAbilityScoreId")]
        public CadAbilityScore? CadAbilityScore { get; set; }
        public int? Value { get; set; }
    }

    public class CharacterSkill
    {
        [Key]
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public int? CadSkillId { get; set; }
        [ForeignKey("CadSkillId")]
        public CadSkill? CadSkill { get; set; }
        public int Level { get; set; }

    }

    public class CharacterSpell
    {
        [Key]
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public int? CadSpellId { get; set; }
        [ForeignKey("CadSpellId")]
        public CadSpell? CadSpell { get; set; }
        public int? Level { get; set; }

    }

    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

}
