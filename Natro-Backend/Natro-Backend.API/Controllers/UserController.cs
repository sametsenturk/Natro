using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natro_Backend.BLL.Operation.UserOperations;
using Natro_Backend.Models.API.User.Request;
using Natro_Backend.Models.API.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natro_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserOperations _userOperations;

        public UserController(UserOperations userOperations)
        {
            _userOperations = userOperations;
        }

        [HttpPost]
        [Route("login")]
        public LoginResponse Login([FromBody] LoginRequest request) => _userOperations.Login(request);

        //[HttpGet]
        //[Route("asd")]
        //public void Asd()
        //{
        //    _userOperations.Asd();
        //}

    }
}
