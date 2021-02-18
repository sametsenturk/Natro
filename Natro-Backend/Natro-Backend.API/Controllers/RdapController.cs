using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using Natro_Backend.Models.Integration.RDAP.Request.Domain;
using Natro_Backend.BLL.Operation.RdapOperations;

namespace Natro_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RdapController : ControllerBase
    {

        private readonly RdapOperations _rdapOperations;

        public RdapController(RdapOperations rdapOperations)
        {
            _rdapOperations = rdapOperations;
        }

        [HttpGet]
        [Route("checkdomain")]
        public async Task<CheckDomainResponseModel> CheckDomain(CheckDomainRequestModel request)
        {
            CheckDomainResponseModel response = await _rdapOperations.CheckDomainAsync(request);
            return response;
        }
    }
}
