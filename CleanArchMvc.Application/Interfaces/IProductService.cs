using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductWithCategoryByProductIdAsync(int? id);
        Task<ProductDto> GetByIdAssync(int? id);
        Task CreateAssync(ProductDto productDto);
        Task UpdateAssync(ProductDto productDto);
        Task RemoveAssync(int? id);
    }
}
