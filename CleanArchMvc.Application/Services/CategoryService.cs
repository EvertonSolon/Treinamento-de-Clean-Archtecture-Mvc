using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAssync(categoryEntity);
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAssync(id);
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntities = await _categoryRepository.GetCategories();
            var categoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntities);
            return categoriesDtos;
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAssync(id).Result;
            await _categoryRepository.RemoveAssync(categoryEntity);

        }

        public async Task Update(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAssync(categoryEntity);
        }
    }
}
