using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API.User.Response
{
    public class LoginResponse : BaseResponse
    {
        public string Email { get; set; }
        public string JWT { get; set; }
    }
}
