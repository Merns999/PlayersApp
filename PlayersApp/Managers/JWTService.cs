﻿using Microsoft.IdentityModel.Tokens;
using PlayersApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PlayersApp.Managers
{
    public class JWTService : IAuthService
    {
        #region Private Methods
        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] SymetricKey = Convert.FromBase64String(SecretKey);
            return new SymmetricSecurityKey(SymetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }
        #endregion
        #region Members
        public string SecretKey { get; set; }
        #endregion
        #region Constructor
        public JWTService(string secretKey)
        {
            SecretKey = secretKey;
        }
        #endregion
        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("TOken empty");
            }

            TokenValidationParameters tokenValidationParameters =  GetTokenValidationParameters();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GenerateToken(IAuthContainerModel model)
        {
            if(model == null|| model.Claims == null || model.Claims.Length == 0)
            {
                throw new ArgumentException("Argument to create token not valid");
            }
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(model.ExpireMinutes)),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if(string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null");

            }

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return tokenValid.Claims;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
