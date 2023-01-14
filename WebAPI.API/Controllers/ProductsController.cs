using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTOs;
using WebAPI.Application.Interfaces;
using WebAPI.Application.Services;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _service.FindAllAsync();
            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(int id)
        {
            var product = await _service.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest("Data Invalid");

            var product = await _service.AddAsync(productDto);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _service.UpdateAsync(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var isDelete = await _service.DeleteAsync(id);
            if (!isDelete)
                return BadRequest();

            return Ok();
        }
    }
}
