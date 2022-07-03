using CleanArchMvc.Domain.Entities;
using System.Text.Json.Serialization;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDto : ProductApiDto
    {
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
