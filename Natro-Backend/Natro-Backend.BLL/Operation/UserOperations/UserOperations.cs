using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Natro_Backend.Constants;
using Natro_Backend.DAL.Abstract;
using Natro_Backend.Models.API.User.Request;
using Natro_Backend.Models.API.User.Response;
using Natro_Backend.Security.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.BLL.Operation.UserOperations
{
    public class UserOperations
    {
        private IConfiguration _configuration;
        private IUserService _userService;
        private IHash _hash;

        public UserOperations(IConfiguration configuration, IUserService userService, IHash hash)
        {
            _userService = userService;
            _hash = hash;
            _configuration = configuration;
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            var user = _userService.Get(x => x.Username == request.Username && x.Password == _hash.Hash(request.Password)).FirstOrDefault();
            if (user != null)
            {
                response.Email = user.Email;
                response.JWT = GenerateJWT(user.ID, user.Username);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = GlobalConstants.ErrorMessageConstants.LoginFailed;
            }
            return response;
        }

        //public void Asd()
        //{
        //    _userService.Add(new Entity.Entities.UserEntity
        //    {
        //        Email = "sametsenturkkk@outlook.com",
        //        Username = "samet",
        //        Password = _hash.Hash("123")
        //    });
        //}

        private string GenerateJWT(int userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTSecret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
