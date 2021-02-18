using Natro_Backend.Models.Integration.RDAP.Request.Domain;
using Natro_Backend.Models.Integration.RDAP.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.RDAP.Abstract
{
    public interface IDomainHelper
    {
        Task<CheckDomainResponseModel> CheckDomain(CheckDomainRequestModel request);
    }
}
