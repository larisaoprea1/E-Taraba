using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.BasketProductDTOs;

namespace ETaraba.Profiles
{
    public class BasketProductProfile : Profile
    {
        public BasketProductProfile()
        {
            CreateMap<BasketProduct, BasketProductDTO>();
            CreateMap<BasketProductDTO, BasketProduct>();
            CreateMap<BasketProduct, BasketProductQuantityUpdateDTO>();
            CreateMap<BasketProductQuantityUpdateDTO, BasketProduct>();
        }
    }
}
