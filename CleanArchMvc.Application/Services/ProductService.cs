using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreateAsync(ProductDto productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            if(productCreateCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productCreateCommand);

        }

        public async Task<ProductDto> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var productEntity = await _mediator.Send(productByIdQuery);
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return productDto;

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            //var productsEntities = await _productRepository.GetProducts();
            //var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(productsEntities);
            //return productsDtos;
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productsQuery);

            var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(result);
            
            return productsDtos;


        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            if (productUpdateCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productUpdateCommand);
        }
    }
}
