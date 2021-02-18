using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.Integration.RDAP.Response.Domain
{
    public class CheckDomainResponseModel : BaseResponse
    {
        public string Domain { get; set; }
        public bool IsAvailableToBuy { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAdress { get; set; }
        public string OwnerPhoneNumber { get; set; }
    }
}
