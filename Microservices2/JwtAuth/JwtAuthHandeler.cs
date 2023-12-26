using JwtAuth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth
{
    public class JwtAuthHandeler
    {
        public const string jwt_Security_key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
        public const int jwt_validate_mins = 20;
        public readonly List<UserAcount> _userAcount;
        public JwtAuthHandeler()
        {
            _userAcount = new List<UserAcount>
            {
                new UserAcount{UserName="Ahmed",Password="Ahmed1",Role="Admin"},
                new UserAcount{UserName="Hassan",Password="Hassan1",Role="User"}
            };
        }

        public AuthenticationResponse GetToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.Name) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;

            //Validation
            var userAcount =_userAcount.FirstOrDefault(x => x.UserName == authenticationRequest.Name && x.Password==authenticationRequest.Password);
            if (userAcount == null)
                return null;
            var tokenSpireTimeSpan = DateTime.Now.AddMinutes(jwt_validate_mins);
            var tokenKey = Encoding.ASCII.GetBytes(jwt_Security_key);
            var claimIdentity = new ClaimsIdentity(new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Name,authenticationRequest.Name),
               new Claim(ClaimTypes.Role,userAcount.Role)
            });

            var signingCreditial = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                Expires = tokenSpireTimeSpan,
                SigningCredentials = signingCreditial
            };

            var jwtTokenSecurityHandeler = new JwtSecurityTokenHandler();
            var securityToken = jwtTokenSecurityHandeler.CreateToken(securityTokenDescriptor);
            var token = jwtTokenSecurityHandeler.WriteToken(securityToken);
            return new AuthenticationResponse
            {
                UserName = userAcount.UserName,
                JwtToken = token,
                ExpireIn = (int)tokenSpireTimeSpan.Subtract(DateTime.Now).TotalSeconds
            };
        }
 
    }
}
