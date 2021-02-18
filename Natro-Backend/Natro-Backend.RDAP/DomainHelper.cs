using AutoMapper;
using Microsoft.Extensions.Configuration;
using Natro_Backend.Models.Integration.RDAP.Request.Domain;
using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using Natro_Backend.RDAP.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Natro_Backend.RDAP
{
    public class DomainHelper : BaseHelper, IDomainHelper
    {

        private IMapper _mapper;

        public DomainHelper(IConfiguration configuration, IMapper mapper) : base(configuration)
        {
            _mapper = mapper;
        }

        public async Task<CheckDomainResponseModel> CheckDomainAsync(CheckDomainRequestModel request)
        {
            CheckDomainResponseModel responseModel = new CheckDomainResponseModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{apiUrl}/domain/{request.Domain}"))
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        responseModel.Domain = request.Domain;
                        responseModel.IsAvailableToBuy = true;
                    }
                    else if (response.StatusCode != HttpStatusCode.InternalServerError)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (apiResponse != null && apiResponse != string.Empty)
                        {
                            WhoisResponse whoisResponse = JsonConvert.DeserializeObject<WhoisResponse>(apiResponse);
                            responseModel = _mapper.Map<WhoisResponse, CheckDomainResponseModel>(whoisResponse);
                        }
                    }
                    else
                        throw new Exception("API down.");
                }
            }
            return responseModel;
        }
    }
}
