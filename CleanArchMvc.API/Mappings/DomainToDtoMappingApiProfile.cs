using AutoMapper;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.API.Mappings
{
    public class DomainToDtoMappingApiProfile : Profile
    {
        public DomainToDtoMappingApiProfile()
        {
            CreateMap<ProductDto, ProductBaseDto>().ReverseMap();
        }
    }
}
