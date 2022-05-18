using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        public async Task CreateAssync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetByIdAssync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProductWithCategoryByProductIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAssync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAssync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
