using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.DTOs
{
    public class ProductDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
