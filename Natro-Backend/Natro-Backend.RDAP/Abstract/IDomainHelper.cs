using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.RDAP.Abstract
{
    public interface IDomainHelper
    {
        Task<CheckDomainResponseModel> CheckDomainAsync(string domain);
    }
}
