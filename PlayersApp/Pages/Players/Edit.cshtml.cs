using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayersApp.Data;
using PlayersApp.Models.Domain;
using PlayersApp.Models.ViewModels;

namespace PlayersApp.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly PlayersDbContext playersDbContext;

        public EditModel(PlayersDbContext playersDbContext)
        {
            this.playersDbContext = playersDbContext;
        }
        [BindProperty]
        public EditPlayerVM editPlayerVM { get; set; }
        public void OnGet(Guid id)
        {
            var player = playersDbContext.Players.Find(id);
            if(player != null)
            {
                editPlayerVM = new EditPlayerVM()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Salary= player.Salary,
                    Phone= player.Phone,
                    Rank= player.Rank
                };
            }

        }
    
        public void OnPost()
        {
            if(editPlayerVM != null)
            {
                var existingPlayer = playersDbContext.Players.Find(editPlayerVM.Id);
                if(existingPlayer != null)
                {
                    existingPlayer.Name = editPlayerVM.Name;
                    existingPlayer.Salary = editPlayerVM.Salary;
                    existingPlayer.Email = editPlayerVM.Email;
                    existingPlayer.Phone = editPlayerVM.Phone;
                    existingPlayer.Rank = editPlayerVM.Rank;

                    playersDbContext.Update(existingPlayer);
                    playersDbContext.SaveChanges();

                    ViewData["Message"] = "Player Edited Succefully";
                }
            }

        }
    }
}
