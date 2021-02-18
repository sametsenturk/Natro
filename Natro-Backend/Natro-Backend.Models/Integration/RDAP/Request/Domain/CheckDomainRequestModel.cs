using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.Integration.RDAP.Request.Domain
{
    public class CheckDomainRequestModel : BaseRequest
    {
        public string Domain { get; set; }
    }
}
