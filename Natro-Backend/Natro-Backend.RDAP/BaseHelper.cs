using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.RDAP
{
    public class BaseHelper
    {
        protected string apiUrl = "";
        public BaseHelper(IConfiguration configuration)
        {
            apiUrl = configuration.GetSection("APIConf").GetSection("RDAP-URL").Value;
        }
    }
}
