using CCRestitution.Data;
using CCRestitution.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CCRestitution
{
    public class CCClaimsTransformation : IClaimsTransformation
    {
        private readonly DataContext _context;

        public CCClaimsTransformation(DataContext context)
        {
            _context = context;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            User? user = await _context.Users.Where(x => x.Identity == principal.Identity.Name).AsNoTracking().FirstOrDefaultAsync();

            if(user != null)
            {
                var ci = (ClaimsIdentity)principal.Identity;

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("UserId", user.Identity.ToString()));
                claims.Add(new Claim("FirstName", user.FirstName));
                claims.Add(new Claim("LastName", user.LastName));
                claims.Add(new Claim("FullName", $"{user.FirstName} {user.LastName}"));
                claims.Add(new Claim("Email", user.Email));
                claims.Add(new Claim("UserRole", user.Role.ToString()));
                ci.AddClaims(claims);
            }

            return await Task.FromResult(principal);

        }
    }
}
