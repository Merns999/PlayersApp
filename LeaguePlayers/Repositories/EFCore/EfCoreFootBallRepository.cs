using LeaguePlayers.Data;
using LeaguePlayers.Models.Domain;

namespace LeaguePlayers.Repositories.EFCore
{
    public class EfCoreFootBallRepository : EfCoreRepository<FootBall, LeaguePlayersDbContext>
    {
        public EfCoreFootBallRepository(LeaguePlayersDbContext context) : base(context)
        {

        }
    }
}
