

namespace PlayersApp.Models.Login
{
    public interface ILogin
    {
        Responce CheckLogin(string Email, string Password);
    }
}
