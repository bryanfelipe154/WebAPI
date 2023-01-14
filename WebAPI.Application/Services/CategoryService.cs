using AutoMapper;
using System.Linq.Expressions;
using WebAPI.Application.DTOs;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application.Services
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

        public async Task<IEnumerable<CategoryDTO>> FindAllAsync()
        {
            var categoriesEntity = await _categoryRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO?> FindByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.FindByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<CategoryDTO?> GetByIdAsync(Expression<Func<CategoryDTO, bool>> predicate)
        {
            var predicateData = _mapper.Map<Expression<Func<Category, bool>>>(predicate);
            var ret = await _categoryRepository.GetByIdAsync(predicateData);

            return _mapper.Map<CategoryDTO>(ret);
        }

        public async Task<CategoryDTO?> AddAsync(CategoryDTO obj)
        {
            var categoryEntity = _mapper.Map<Category>(obj);
            await _categoryRepository.AddAsync(categoryEntity);
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO obj)
        {
            var categoryEntity = _mapper.Map<Category>(obj);
            await _categoryRepository.UpdateAsync(categoryEntity);
            return obj;
        }
    }
}
