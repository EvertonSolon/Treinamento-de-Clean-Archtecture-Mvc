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
        public async Task<ActionResult<IEnumerable<ProductBaseDto>>> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null)
            {
                return NotFound("Products not found");
            }

            var productsApiDto = _mapper.Map<IEnumerable<ProductBaseDto>>(products);

            return Ok(productsApiDto);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductBaseDto>> Get(int id)
        {
            var productDto = await _productService.GetByIdAsync(id);

            if (productDto == null) return NotFound("Product not found");

            var productApiDto = _mapper.Map<ProductBaseDto>(productDto);

            return Ok(productApiDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductBaseDto productApiDto)
        {
            if (productApiDto == null) return BadRequest("Invalid Data");

            var productDto = _mapper.Map<ProductDto>(productApiDto);

            await _productService.CreateAsync(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productApiDto.Id }, productApiDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductBaseDto productApiDto)
        {

            if (id != productApiDto.Id || productApiDto == null) return BadRequest();

            var productDto = _mapper.Map<ProductDto>(productApiDto);

            await _productService.UpdateAsync(productDto);

            return Ok(productApiDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductBaseDto>> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null) return NotFound("Product not found");

            await _productService.RemoveAsync(id);

            return Ok(product);

        }
    }
}
