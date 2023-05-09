using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayersApp.Data;
using PlayersApp.Models.Domain;
using PlayersApp.Models.ViewModels;

namespace PlayersApp.Pages.Players
{
    public class AddModel : PageModel
    {
        private readonly PlayersDbContext playersDbContext;

        public AddModel(PlayersDbContext playersDbContext)
        {
            this.playersDbContext = playersDbContext;
        }

        [BindProperty]
        public AddPlayerVM addPlayerVM { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var player = new Player
            {
                Name = addPlayerVM.Name,
                Email = addPlayerVM.Email,
                Salary = addPlayerVM.Salary,
                Phone = addPlayerVM.Phone,
                Rank = addPlayerVM.Rank
            };

            playersDbContext.Players.Add(player);
            playersDbContext.SaveChanges();

            ViewData["Message"] = "Player Added Succefully";
        }
    }
}
