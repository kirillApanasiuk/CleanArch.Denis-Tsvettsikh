using AutoMapper;
using Domain;
using Domain.Entities;
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
            CreateMap<CreateOrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();

        }
    }
}
