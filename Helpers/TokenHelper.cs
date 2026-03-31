using EasyTask.Common;
using EasyTask.Models.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyTask.Helpers;

public static class TokenGenerator
{
    public static string Generate(string id, string mobile, Role roleID)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("ID", id),
                new Claim("RoleID", roleID.ToString()),
                new Claim(ClaimTypes.MobilePhone, mobile)
            }),
            Expires = DateTime.Now.AddDays(5),
            Issuer = "EasyTask",
            Audience = "EasyTask-Users",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey)), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
