using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using Natro_Backend.BLL.Operation.RdapOperations;

namespace Natro_Backend.API.Controllers
{
    public class RdapController : BaseController
    {

        private readonly RdapOperations _rdapOperations;

        public RdapController(RdapOperations rdapOperations)
        {
            _rdapOperations = rdapOperations;
        }

        [HttpGet]
        [Route("checkdomain/{domain}")]
        public async Task<CheckDomainResponseModel> CheckDomain(string domain)
        {
            CheckDomainResponseModel response = await _rdapOperations.CheckDomainAsync(domain);
            return response;
        }
    }
}
