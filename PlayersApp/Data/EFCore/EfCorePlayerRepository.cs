using PlayersApp.Models.Domain;

namespace PlayersApp.Data.EFCore
{
    public class EfCorePlayerRepository : EfCoreRepository<Player,PlayersDbContext>
    {
        public EfCorePlayerRepository(PlayersDbContext context) : base(context)
        {

        }
    }
}
