using AutoMapper;
using System.Linq.Expressions;
using WebAPI.Application.DTOs;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> FindAllAsync()
        {
            var categoriesEntity = await _productRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(categoriesEntity);
        }

        public async Task<ProductDTO?> FindByIdAsync(int id)
        {
            var ProductEntity = await _productRepository.FindByIdAsync(id);
            return _mapper.Map<ProductDTO>(ProductEntity);
        }

        public async Task<ProductDTO?> GetByIdAsync(Expression<Func<ProductDTO, bool>> predicate)
        {
            var predicateData = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            var ret = await _productRepository.GetByIdAsync(predicateData);

            return _mapper.Map<ProductDTO>(ret);
        }

        public async Task<ProductDTO?> AddAsync(ProductDTO obj)
        {
            var productEntity = _mapper.Map<Product>(obj);
            await _productRepository.AddAsync(productEntity);
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO obj)
        {
            var productEntity = _mapper.Map<Product>(obj);
            await _productRepository.UpdateAsync(productEntity);
            return obj;
        }
    }
}
