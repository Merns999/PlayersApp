using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayersApp.Data;
using PlayersApp.Models.Domain;

namespace PlayersApp.Pages.Players
{
    public class ListModel : PageModel
    {
        private readonly PlayersDbContext playersDbContext;

        public List<Player> players { get; set; }

        public ListModel(PlayersDbContext playersDbContext)
        {
            this.playersDbContext = playersDbContext;
        }

        public void OnGet()
        {
            players = playersDbContext.Players.ToList();
        }
    }
}
