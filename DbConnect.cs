using Microsoft.EntityFrameworkCore;
using System.Configuration;
using api_projeto_final.DataModels;

namespace api_projeto_final
{
    public class DbConnect : DbContext
    {

        public DbSet<user> users { get; set; }
        public DbSet<token> tokens { get; set; }
        public DbSet<auth> auth { get; set; }


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
        }
    }
}