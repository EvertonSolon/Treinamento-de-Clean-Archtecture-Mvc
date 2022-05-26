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
    //    Task<ProductDto> GetProductWithCategoryByProductIdAsync(int? id);
    //    Task<ProductDto> GetByIdAsync(int? id);
    //    Task CreateAsync(ProductDto productDto);
    //    Task UpdateAsync(ProductDto productDto);
    //    Task RemoveAsync(int? id);
    }
}
