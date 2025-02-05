﻿using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using Natro_Backend.RDAP.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.BLL.Operation.RdapOperations
{
    public class RdapOperations
    {
        private IDomainHelper _domainHelper;

        public RdapOperations(IDomainHelper domainHelper)
        {
            _domainHelper = domainHelper;
        }

        public async Task<CheckDomainResponseModel> CheckDomainAsync(string domain)
        {
            CheckDomainResponseModel response = await _domainHelper.CheckDomainAsync(domain);
            return response;
        }
    }
}
