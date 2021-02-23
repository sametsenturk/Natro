using AutoMapper;
using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natro_Backend.API.Profiles.Integration.RDAP
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<WhoisResponse, CheckDomainResponseModel>()
                .ForMember(x => x.Domain, opt => opt.MapFrom(src => src.ldhName))
                .ForMember(x => x.IsAvailableToBuy, opt => opt.MapFrom(src => false))
                .ForMember(x => x.Nameserver1, opt => opt.MapFrom(src => src.nameservers[0].ldhName))
                .ForMember(x => x.Nameserver2, opt => opt.MapFrom(src => src.nameservers[1].ldhName))
                .ForMember(x => x.LastChange, opt => opt.MapFrom(src => src.events.FirstOrDefault(x => x.eventAction == "last update of RDAP database").eventDate))
                .ForMember(x => x.ExpireDate, opt => opt.MapFrom(src => src.events.FirstOrDefault(x => x.eventAction == "expiration").eventDate));
        }
    }
}
