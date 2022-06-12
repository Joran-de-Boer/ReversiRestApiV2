using Microsoft.EntityFrameworkCore;
using ReversieISpelImplementatie.Model;

namespace ReversiRestApiV2.DAL
{
    public class SpelContext : DbContext
    {
        public SpelContext(DbContextOptions<SpelContext> options) : base(options){}
        public DbSet<SpelJson> Spellen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ReversiV2Database");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SpelJson>().HasData(new SpelJson(1, "Pablo", "Escobar1", "Tra", "Tre", new Spel().Bord, Kleur.Wit));
            //modelBuilder.Entity<SpelJson>().HasData(new SpelJson(new ReversieISpelImplementatie.Model.Spel() {Token = "Hey", AandeBeurt = ReversieISpelImplementatie.Model.Kleur.Zwart, Speler1Token = "Speler1", Speler2Token = "Speler2", Omschrijving = "A niffauw" }));
            //modelBuilder.Entity<SpelJson>().HasData(new SpelJson(new ReversieISpelImplementatie.Model.Spel() {Token = "Greetings", AandeBeurt = ReversieISpelImplementatie.Model.Kleur.Wit, Speler1Token = "S1", Speler2Token = "S2", Omschrijving = "Skra" }));
        }
    }
}
