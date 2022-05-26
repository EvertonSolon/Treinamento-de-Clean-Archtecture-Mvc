using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mappings
{
    public class DtoToCommandMapping : Profile
    {
        public DtoToCommandMapping()
        {
            CreateMap<ProductCreateCommand, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateCommand, ProductDto>().ReverseMap();
        }
    }
}
