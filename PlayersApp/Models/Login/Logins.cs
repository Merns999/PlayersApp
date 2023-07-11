using Azure;
using PlayersApp.Data.EFCore;
using PlayersApp.Models.Domain;

namespace PlayersApp.Models.Login
{
    public class Logins 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
