using Microsoft.EntityFrameworkCore;
using System.Configuration;
using api_projeto_final.DataModels;

namespace api_projeto_final
{
    public class DbConnect : DbContext
    {
        // a parte de usuario
        public DbSet<user> users { get; set; }
        public DbSet<token> tokens { get; set; }
        public DbSet<auth> auth { get; set; }

        // a parte de personagem
        public DbSet<Character> Characters { get; set; }
        public DbSet<CadAbilityScore> CadAbilityScore { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceModifiers> RacesModifiers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassModifiers> ClassesModifiers { get; set; }
        public DbSet<CharacterAbilityScore> CharacterAbilityScores { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterSpell> CharacterSpells { get; set; }
        public DbSet<Equipment> Equipment { get; set; }


        public DbConnect() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionStringSettings settings = System.Configuration.ConfigurationManager.ConnectionStrings["SupabaseConnection"];
            string retorno = "";
            if (settings != null)
            {
                retorno = settings.ConnectionString;
            }
            optionsBuilder.UseNpgsql(retorno);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<token>()
                .HasOne(token => token.user)
                .WithOne(user => user.token)
                .HasForeignKey<token>(token => token.userId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<token>()
                .Property(e => e.created_at)
                .HasDefaultValue(DateTimeOffset.UtcNow);

            modelBuilder.Entity<token>()
                .Property(e => e.expires_at)
                .HasDefaultValue(DateTimeOffset.UtcNow.AddHours(4));


            modelBuilder.Entity<auth>()
                .HasOne(auth => auth.user)
                .WithOne(user => user.auth)
                .HasForeignKey<auth>(auth => auth.userId)
                .OnDelete(DeleteBehavior.Cascade);


            // relacionamentos dos personagens

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Race)
                .WithMany()
                .HasForeignKey(c => c.RaceId);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Class)
                .WithMany()
                .HasForeignKey(c => c.ClassId);

            modelBuilder.Entity<CharacterAbilityScore>()
                .HasOne(cas => cas.Character)
                .WithMany(c => c.AbilityScore)
                .HasForeignKey(cas => cas.CharacterId);

            modelBuilder.Entity<CharacterAbilityScore>()
                .HasOne(cas => cas.CadAbilityScore)
                .WithMany(ca => ca.CharacterAbilityScore)
                .HasForeignKey(cas => cas.CadAbilityScoreId);

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CharacterId);

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(cs => cs.CadSkill)
                .WithMany()
                .HasForeignKey(cs => cs.CadSkillId);

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(css => css.Character)
                .WithMany(c => c.Spells)
                .HasForeignKey(css => css.CharacterId);

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(css => css.CadSpell)
                .WithMany()
                .HasForeignKey(css => css.CadSpellId);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Character)
                .WithMany(c => c.Equipment)
                .HasForeignKey(e => e.CharacterId);

            modelBuilder.Entity<CadAbilityScore>()
                .HasMany(cad => cad.RaceModifiers)
                .WithOne(rm => rm.CadAbilityScore)
                .HasForeignKey(rm => rm.CadAbilityScoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CadAbilityScore>()
                .HasMany(cad => cad.ClassModifiers)
                .WithOne(cm => cm.CadAbilityScore)
                .HasForeignKey(cm => cm.CadAbilityScoreId)
                .OnDelete(DeleteBehavior.Restrict);

/*            modelBuilder.Entity<Class>()
                .HasMany(c => c.ClassModifiers)
                .WithOne(cm => cm.Class)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClassModifiers>()
                .HasOne(cm => cm.Class)
                .WithMany(c => c.ClassModifiers)
                .HasForeignKey(cm => cm.ClassId);

            modelBuilder.Entity<Race>()
                .HasMany(r => r.RaceModifiers)
                .WithOne(rm => rm.Race)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RaceModifiers>()
                .HasOne(rm => rm.Race)
                .WithMany(r => r.RaceModifiers)
                .HasForeignKey(rm => rm.RaceId);*/

            // coisas do cad

        }

        /*public DbSet<api_projeto_final.DataModels.CadAbilityScore>? CadAbilityScore { get; set; }*/

        public DbSet<api_projeto_final.DataModels.CadSkill>? CadSkill { get; set; }

        public DbSet<api_projeto_final.DataModels.CadSpell>? CadSpell { get; set; }
    }
}

/*// n sei ao certo
modelBuilder.Entity<ClassModifiers>()
    .HasOne(cm => cm.Class)
    .WithMany(c => c.ClassModifiers)
    .HasForeignKey(cm => cm.ClassId);

modelBuilder.Entity<Race>()
    .HasMany(r => r.RaceModifiers)
    .WithOne(rm => rm.Race)
    .OnDelete(DeleteBehavior.Cascade);

modelBuilder.Entity<RaceModifiers>()
    .HasOne(rm => rm.Race)
    .WithMany(r => r.RaceModifiers)
    .HasForeignKey(rm => rm.RaceId);

// coisas do cad
modelBuilder.Entity<CadAbilityScore>()
    .HasMany(cad => cad.RaceModifiers)
    .WithOne(rm => rm.CadAbilityScore)
    .HasForeignKey(rm => rm.CadAbilityScoreId)
    .OnDelete(DeleteBehavior.Restrict);

modelBuilder.Entity<CadAbilityScore>()
    .HasMany(cad => cad.ClassModifiers)
    .WithOne(cm => cm.CadAbilityScore)
    .HasForeignKey(cm => cm.CadAbilityScoreId)
    .OnDelete(DeleteBehavior.Restrict);*/