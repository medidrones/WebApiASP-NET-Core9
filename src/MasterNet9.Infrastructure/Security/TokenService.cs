using MasterNet9.Application.Interfaces;
using MasterNet9.Domain;
using MasterNet9.Persistence;
using MasterNet9.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MasterNet9.Infrastructure.Security;

public class TokenService : ITokenService
{
    private readonly MasterNet9DbContext _context;
    private readonly IConfiguration _configuration;

    public TokenService(MasterNet9DbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> CreateToken(AppUser user)
    {
        var policies = await _context.Database.SqlQuery<string>($@"
                SELECT
                    aspr.ClaimValue
                FROM AspNetUsers a
                    LEFT JOIN AspNetUserRoles ar
                        ON a.Id=ar.UserId
                    LEFT JOIN AspNetRoleClaims aspr
                        ON ar.RoleId = aspr.RoleId
                    WHERE a.Id = {user.Id}
        ").ToListAsync();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email!)
        };

        foreach (var policy in policies)
        {
            if (policy is not null)
            {
                claims.Add(new (CustomClaims.POLICIES, policy));
            }
        }

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["TokenKey"]!)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
