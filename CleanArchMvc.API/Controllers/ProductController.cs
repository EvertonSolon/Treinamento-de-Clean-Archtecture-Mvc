using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductApiDto>>> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductApiDto>> Get(int id)
        {
            var productDto = await _productService.GetByIdAsync(id);

            if (productDto == null) return NotFound("Product not found");

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductApiDto productApiDto)
        {
            if (productApiDto == null) return BadRequest("Invalid Data");

            ProductDto productDto = MapProductApiToProductDto(productApiDto);

            await _productService.CreateAsync(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productApiDto.Id }, productApiDto);
        }

        private static ProductDto MapProductApiToProductDto(ProductApiDto productApiDto)
        {
            return new ProductDto
            {
                Id = productApiDto.Id,
                Name = productApiDto.Name,
                Description = productApiDto.Description,
                Price = productApiDto.Price,
                Stock = productApiDto.Stock,
                Image = productApiDto.Image,
                CategoryId = productApiDto.CategoryId
            };
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductApiDto productApiDto)
        {
            if (id != productApiDto.Id || productApiDto == null) return BadRequest();

            ProductDto productDto = MapProductApiToProductDto(productApiDto);

            await _productService.UpdateAsync(productDto);

            return Ok(productApiDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductApiDto>> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null) return NotFound("Product not found");

            await _productService.RemoveAsync(id);

            return Ok(product);

        }
    }
}
