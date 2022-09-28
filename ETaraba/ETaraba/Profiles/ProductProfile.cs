using AutoMapper;
using ETaraba.Domain.Models;
using ETaraba.DTOs.ProductDTOs;

namespace ETaraba.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile(){ 
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductForCreationDTO, Product>();
            CreateMap<ProductForUpdatingDTO, Product>();
        }
    }
}
