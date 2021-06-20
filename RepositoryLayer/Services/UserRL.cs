using CommonLayer;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
       
        private UserContext _userDbContext;
        public UserRL(UserContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public Users AddUser(Users newuser)
        {
            _userDbContext.Users.Add(newuser);
            _userDbContext.SaveChanges();
            return newuser;
        }
        public string Login(string email, string password)
        {
            var result = _userDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (result == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("HelloThisTokenIsGeneretedByMe");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

