using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.BasketDTOs;

namespace ETaraba.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDTO>();
            CreateMap<BasketDTO, Basket>();
        }
    }
}
