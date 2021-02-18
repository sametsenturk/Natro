using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Natro_Backend.Models.API.User.Request
{
    public class LoginRequest : BaseRequest
    {
        [Required, MaxLength(25)]
        public string Username { get; set; }
        [Required, MaxLength(25)]
        public string Password { get; set; }
    }
}
