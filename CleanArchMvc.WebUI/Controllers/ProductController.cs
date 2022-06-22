using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetViewBagCategories();

            return View();
        }

        private async Task GetViewBagCategories(int? categoryId = null)
        {
            var categoriesDto = await _categoryService.GetCategories();
            ViewBag.CategoryId = categoryId == null ? 
                            new SelectList(categoriesDto, "Id", "Name") :
                            new SelectList(categoriesDto, "Id", "Name", categoryId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

            await _productService.CreateAsync(productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDto = await _productService.GetByIdAsync(id);

            if (productDto == null) return NotFound();

            await GetViewBagCategories(productDto.CategoryId);
            
            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(productDto);
                
                return RedirectToAction(nameof(Index));
            }

            await GetViewBagCategories(productDto.CategoryId);

            return View(productDto);

        }
    }
}
