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
        public void OnPost()
        {
            if (deletePlayerVM != null)
            {
                var existingPlayer = playersDbContext.Players.Find(deletePlayerVM.Id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name =   deletePlayerVM.Name;
                    existingPlayer.Salary = deletePlayerVM.Salary;
                    existingPlayer.Email =  deletePlayerVM.Email;
                    existingPlayer.Phone =  deletePlayerVM.Phone;
                    existingPlayer.Rank =   deletePlayerVM.Rank;

                    playersDbContext.Remove(existingPlayer);
                    playersDbContext.SaveChanges();

                    ViewData["Message"] = "Player deleted Succefully";
                }
            }
            //return RedirectToPage("/Players/List");
        }
    }
}
