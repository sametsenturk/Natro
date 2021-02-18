using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Natro_Backend.Models.Integration.RDAP.Request.Domain
{
    public class CheckDomainRequestModel : BaseRequest
    {
        [Required, MaxLength(30)]
        public string Domain { get; set; }
    }
}
