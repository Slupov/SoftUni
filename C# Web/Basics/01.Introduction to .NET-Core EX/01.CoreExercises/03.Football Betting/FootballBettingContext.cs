using Microsoft.EntityFrameworkCore;
using _03.Football_Betting.Models;

namespace _03.Football_Betting
{
    public class FootballBettingContext : DbContext
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetGame> BetGames { get; set; }
        public DbSet<ResultPrediction> ResultPredictions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                @"Server=.;Database=BankSystemDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasOne(team => team.Town)
                .WithMany(town => town.Teams);

            modelBuilder.Entity<Town>()
                .HasOne(town => town.Country)
                .WithMany(country => country.Towns);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(position => position.Players);

            //TODO: Mapping tables

            modelBuilder.Entity<PlayersGames>()
                .HasKey(sc => new {sc.PlayerId, sc.GameId});

            modelBuilder.Entity<PlayersGames>()
                .HasOne<Player>(sc => sc.Player)
                .WithMany(s => s.Games)
                .HasForeignKey(sc => sc.PlayerId);

            modelBuilder.Entity<PlayersGames>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Players)
                .HasForeignKey(sc => sc.GameId);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.PlayerStatistics)
                .WithOne(ps => ps.Player);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.PlayerStatistics)
                .WithOne(ps => ps.Game);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Round)
                .WithMany(r => r.Games);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Competition)
                .WithMany(c => c.Games);

            //TODO: Mapping tables

            modelBuilder.Entity<GamesBets>()
                .HasKey(sc => new {sc.GameId, sc.BetId});

            modelBuilder.Entity<GamesBets>()
                .HasOne<Game>(sc => sc.Game)
                .WithMany(s => s.Bets)
                .HasForeignKey(sc => sc.GameId);

            modelBuilder.Entity<GamesBets>()
                .HasOne<Bet>(sc => sc.Bet)
                .WithMany(s => s.Games)
                .HasForeignKey(sc => sc.BetId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.BetGames)
                .WithOne(bg => bg.Game);

            modelBuilder.Entity<Bet>()
                .HasMany(b => b.BetGames)
                .WithOne(bg => bg.Bet);

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets);

            modelBuilder.Entity<BetGame>()
                .HasKey(bg => new {bg.BetId, bg.GameId});

            modelBuilder.Entity<BetGame>()
                .HasOne(bg => bg.ResultPrediction)
                .WithOne(rp => rp.BetGame);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new {ps.GameId, ps.PlayerId});

            modelBuilder.Entity<Competition>()
                .HasOne(c => c.Type)
                .WithMany(t => t.Competitions);
        }
    }
}