using Microsoft.EntityFrameworkCore;
using PlayersApp.Models.Domain;

namespace PlayersApp.Data
{
    public class PlayersDbContext : DbContext
    {

        public PlayersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
