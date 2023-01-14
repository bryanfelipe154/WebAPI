using AutoMapper;
using WebAPI.Application.DTOs;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
