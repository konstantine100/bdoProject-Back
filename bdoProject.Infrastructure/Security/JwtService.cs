using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bdoProject.Application.Interfaces.Security;
using bdoProject.Domain.Entities.Employees;
using Microsoft.IdentityModel.Tokens;

namespace bdoProject.Infrastructure.Security;

public sealed class JwtService : IJwtService
{
    private readonly JwtSettings _settings;

    public JwtService(JwtSettings settings) => _settings = settings;

    public string GenerateAccessToken(Employee user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.EmployeeId),
            new("email", user.Email),
            new("role", user.Role.ToString())
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SigningKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(_settings.AccessTokenDays),
            signingCredentials: credentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}