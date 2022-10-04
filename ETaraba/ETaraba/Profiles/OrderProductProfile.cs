using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.OrderProductDTOs;

namespace ETaraba.Profiles
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
        }
    }
}
