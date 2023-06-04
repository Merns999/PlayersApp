using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeaguePlayers.Models.Domain;

namespace LeaguePlayers.Data
{
    public class LeaguePlayersContext : DbContext
    {
        public LeaguePlayersContext(DbContextOptions<LeaguePlayersContext> options)
            : base(options)
        {
        }

        public DbSet<LeaguePlayers.Models.Domain.BasketBall> BasketBall { get; set; } = default!;

        public DbSet<LeaguePlayers.Models.Domain.FootBall>? FootBall { get; set; }
    }
}
