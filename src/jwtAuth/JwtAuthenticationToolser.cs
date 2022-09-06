using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwtAuth
{
    public class JwtAuthenticationToolser
    {
        private readonly string _key;

        public JwtAuthenticationToolser(string key)
        {
            _key = key;
        }

        public string Authentication(string username)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey= Encoding.ASCII.GetBytes(_key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username),
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                                      SecurityAlgorithms.HmacSha256Signature)
            };
            var token= tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
