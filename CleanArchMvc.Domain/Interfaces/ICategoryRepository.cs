using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetByIdAssync(int? id);
        Task<Category> CreateAssync(Category category);
        Task<Category> UpdateAssync(Category category);
        Task<Category> RemoveAssync(Category category);
    }
}
