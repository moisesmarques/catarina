using Catarina.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catarina.Web.Providers.Authorization
{
    public static class TokenProvider
    {
        public static string Create( ApplicationUser user, params string[] roles )
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes( "xecretKeywqejane" );

            var claims = new List<Claim>();

            claims.Add( new Claim( ClaimTypes.Name, user.UserName.ToString() ) );

            foreach(var role in roles)
                claims.Add( new Claim( ClaimTypes.Role, role) );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( claims.ToArray() ),

                Expires = DateTime.UtcNow.AddMinutes(15),

                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey( key ), SecurityAlgorithms.HmacSha256Signature )
            };

            var token = tokenHandler.CreateToken( tokenDescriptor );

            return tokenHandler.WriteToken( token );
        }
    }
}
