﻿

using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))  //Custom map source Id for when AutoMapper can not infer it.
                .ReverseMap();                                           //Reverse above map to allow mapping from OrderViewModel to Order aswell.

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
