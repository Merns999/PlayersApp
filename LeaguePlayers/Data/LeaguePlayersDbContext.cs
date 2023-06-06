using LeaguePlayers.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaguePlayers.Data
{
    public class LeaguePlayersDbContext : DbContext
    {
        public LeaguePlayersDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FootBall> FootBall { get; set; }
        public DbSet<BasketBall> BasketBall { get; set; }
    }
}

