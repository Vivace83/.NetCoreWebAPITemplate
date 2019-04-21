using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CoreApi.Models;
using CoreApi.Helpers;

namespace asp.Services
{
    public interface IUserService
    {
        WebUsers Authenticate(string username, string password);
        IEnumerable<WebUsers> GetAll();
        string GetRole(int UserId);
    }


    public class UserService : IUserService
    {

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<WebUsers> _users = new List<WebUsers>
        {
            new WebUsers { Id = 1,Token = "", FirstName = "Test", Surname = "User", Username = "Vernon", Password = "test",Email="t@t.com",Role = "Admin"}
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public WebUsers Authenticate(string username, string password)
        {
            try
            {
                //var context = new your_DB_Context();
                //var user = context.WebUsers.SingleOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

                //using TestUser manual List
                var user = _users.SingleOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

                // return null if user not found
                if (user == null)
                {
                    //your code for handling failed log in for user
                    return null;

                }

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //BUILDING YOUR CUSTOM JWT
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim("FirstName",user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Role", user.Role),
                    }),
                    Expires = DateTime.UtcNow.AddHours(8), //SET EXPIRY TIME HERE
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;

                return user;
            }
            catch(Exception err)
            {
                //LOG HERE IF NEEDED
            }
            return null;
        }

        public IEnumerable<WebUsers> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }

        public string GetRole(int UserId)
        {
            //var context = new your_DB_Context();
            //return context.WebUsers.SingleOrDefault(x => x.Id == UserId).Role;
            return _users.SingleOrDefault(x => x.Id == UserId).Role;
        }
        
    }
}