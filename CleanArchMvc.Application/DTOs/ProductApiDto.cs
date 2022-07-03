using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductApiDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [MinLength(5), MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required!")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [DisplayName("Product image")]
        [MaxLength(250)]
        public string Image { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
