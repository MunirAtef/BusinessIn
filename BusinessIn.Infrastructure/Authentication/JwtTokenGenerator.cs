using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessIn.Application.Common.Authentication;
using BusinessIn.Domain.Constants;
// using BusinessIn.Application.Secrets;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BusinessIn.Infrastructure.Authentication;


public class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator {
    private readonly JwtSettings _settings = jwtSettings.Value;

    public string CreateToken(EmployeeEntity employee, TokenType type = TokenType.AccessToken) {
        var isAccessToken = type == TokenType.AccessToken;
        var key = isAccessToken ? _settings.AccessTokenKey : _settings.RefreshTokenKey;
        var minutes = isAccessToken ? _settings.AccessTokenExpireIn : _settings.RefreshTokenExpireIn;

        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(new[] {
                new Claim(Claims.Id, employee.Id.ToString()),
                new Claim(Claims.Role, Policies.RegularEmployee)
            }),
            Expires = DateTime.UtcNow.AddMinutes(minutes),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        Console.WriteLine(token);

        return tokenHandler.WriteToken(token);
    }
}