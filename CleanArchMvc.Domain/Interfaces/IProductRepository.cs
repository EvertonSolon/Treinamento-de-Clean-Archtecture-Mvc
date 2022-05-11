﻿using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByCategoryIdAsync(int? id);
        Task<Product> GetByIdAssync(int? id);
        Task<Product> CreateAssync(Product category);
        Task<Product> UpdateAssync(Product category);
        Task<Product> RemoveAssync(int id);
    }
}
