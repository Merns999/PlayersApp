using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace PlayersApp.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        #region Public Methods
        public int ExpireMinutes { get; set; } = 10080;
        public string SecretKey { get; set; } = "";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
        #endregion
    }
}
