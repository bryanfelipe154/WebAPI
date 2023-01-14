using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebAPI.Domain.Entities;
using System.Text.Json.Serialization;

namespace WebAPI.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
