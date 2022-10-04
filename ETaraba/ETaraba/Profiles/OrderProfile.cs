using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.OrderDTOs;

namespace ETaraba.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderForCreateDTO, Order>();
        }
    }
}
