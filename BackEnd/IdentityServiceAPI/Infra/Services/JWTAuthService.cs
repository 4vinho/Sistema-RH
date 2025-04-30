using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServiceAPI;

public class JWTAuthService(IConfiguration ? configuration) : IJWTAuthService
{
    public string GenerateTokenString(LoginModel loginModel, string role)
    {
        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Email, loginModel.Email),
            new Claim(ClaimTypes.Role, role)
        };

        var securityKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        var securityCred = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken= new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            signingCredentials: securityCred
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return tokenString;
    }
}
