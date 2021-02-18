using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API
{
    public class BaseResponse
    {        
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
