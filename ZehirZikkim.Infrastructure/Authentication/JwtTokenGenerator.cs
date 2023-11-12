using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Services;
using ZehirZikkim.Domain.Entities;
using ZehirZikkim.Infrastructure.Services;

namespace ZehirZikkim.Infrastructure.Authentication;


public class jwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings jwtSettings;
    private  readonly IDateTimeProvider dateTimeProvider;

    public jwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        this.dateTimeProvider = dateTimeProvider;
        this.jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user) {

   

    SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Access.Secret)),
            SecurityAlgorithms.HmacSha256
        );
        Claim[] claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
          
        
        JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Access.Issuer,
                expires: dateTimeProvider.UtcNow.AddMinutes(
                    jwtSettings.Access.ExpiryMinutes
                ),
                audience: jwtSettings.Access.Audience,
                claims: claims,
                signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}