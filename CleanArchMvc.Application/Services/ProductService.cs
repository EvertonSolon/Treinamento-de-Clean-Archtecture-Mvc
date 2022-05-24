using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDto> GetByIdAsync(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsEntities = await _productRepository.GetProducts();
            var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(productsEntities);
            return productsDtos;

        }

        public async Task<ProductDto> GetProductWithCategoryByProductIdAsync(int? id)
        {
            var productWithCategoryEntity = await _productRepository.GetProductWithCategoryByProductIdAsync(id);
            var productsDtos = _mapper.Map<ProductDto>(productWithCategoryEntity);
            return productsDtos;
        }

        public async Task RemoveAsync(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }
    }
}
