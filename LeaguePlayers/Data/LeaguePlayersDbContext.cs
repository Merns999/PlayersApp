using LeaguePlayers.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaguePlayers.Data
{
    public class LeaguePlayersDbContext : DbContext
    {
        public LeaguePlayersDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FootBall> FootBallPlayers { get; set; }
        public DbSet<BasketBall> BasketBalllayers { get; set; }
    }
}

