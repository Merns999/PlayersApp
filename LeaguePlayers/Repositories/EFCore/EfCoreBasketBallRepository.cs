using LeaguePlayers.Data;
using LeaguePlayers.Models.Domain;

namespace LeaguePlayers.Repositories.EFCore
{
    public class EfCoreBasketBallRepository : EfCoreRepository<BasketBall, LeaguePlayersDbContext>
    {
        public EfCoreBasketBallRepository(LeaguePlayersDbContext context) : base(context)
        {

        }
    }
}
