using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth
{
    public static class CustomJwtExtention
    {
        public const string jwt_Security_key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

        public static void AddCustomJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(
                //o =>{
                //o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                //o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;}
                JwtBearerDefaults.AuthenticationScheme
                )
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtAuthHandeler.jwt_Security_key))
                };
            });
        }
    }
}
