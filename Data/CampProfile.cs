﻿using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<CampModel, Camp>()
             .ForMember(camp => camp.CampId, o => o.Ignore())
             .ForPath(camp => camp.Location.VenueName, o => o.MapFrom(campVM => campVM.Venue))
             .ReverseMap();
            /*.ForMember(cm => cm.AddressLine1, o => o.MapFrom(c => c.Location.Address1))
              .ForMember(cm => cm.AddressLine2, o => o.MapFrom(c => c.Location.Address2))
              .ForMember(cm => cm.AddressLine3, o => o.MapFrom(c => c.Location.Address3))
              .ForMember(cm => cm.CityTown, o => o.MapFrom(c => c.Location.CityTown))
              .ForMember(cm => cm.StateProvince, o => o.MapFrom(c => c.Location.StateProvince))
              .ForMember(cm => cm.PostalCode, o => o.MapFrom(c => c.Location.PostalCode))
              .ForMember(cm => cm.Country, o => o.MapFrom(c => c.Location.Country));*/
        }
    }
}
