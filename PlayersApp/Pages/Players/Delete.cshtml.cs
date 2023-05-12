using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayersApp.Data;
using PlayersApp.Models.ViewModels;

namespace PlayersApp.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly PlayersDbContext playersDbContext;


        public DeleteModel(PlayersDbContext playersDbContext)
        {
            this.playersDbContext = playersDbContext;
        }
        [BindProperty]
        public DeletePlayerVM deletePlayerVM{ get; set; }

        public void OnGet()
        {
           
        }
        public void OnPost(Guid Id)
        {
            if (deletePlayerVM != null)
            {
                var existingPlayer = playersDbContext.Players.Find(Id);
                if (existingPlayer != null)
                {
                    
                    playersDbContext.Remove(existingPlayer);
                    playersDbContext.SaveChanges();

                    ViewData["Message"] = "Player deleted Succefully";
                }
            }
            //return RedirectToPage("/Players/List");
        }
    }
}
