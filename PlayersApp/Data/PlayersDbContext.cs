
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayersApp.Models.Domain;

namespace PlayersApp.Data
{
    public class PlayersDbContext : IdentityDbContext
    {

        public PlayersDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
