using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
