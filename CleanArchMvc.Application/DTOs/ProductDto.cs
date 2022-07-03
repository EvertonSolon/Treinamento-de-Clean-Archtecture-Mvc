using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDto : ProductBaseDto
    {
        public Category Category { get; set; }
    }
}
