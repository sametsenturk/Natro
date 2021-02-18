﻿using AutoMapper;
using Natro_Backend.Models.Integration.RDAP.Response;
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
                .ForMember(x => x.Domain, opt => opt.MapFrom(src => src.Rootobject.ldhName))
                .ForMember(x => x.IsAvailableToBuy, opt => opt.MapFrom(src => false))
                .ForMember(x => x.OwnerName, opt => opt.MapFrom(src => src.Entity.entities[0].vcardArray[5].ToString())); // TODO GET OWNER DETAILS
        }
    }
}
