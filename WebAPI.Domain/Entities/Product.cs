using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Validation;

namespace WebAPI.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public Product(string name, string description, decimal price)
        {
            Validade(name, description, price);

            Name = name;
            Description = description;
            Price = price;
        }

        private void Validade(string name, string description, decimal price)
        {
            DomainValidation.Check(string.IsNullOrEmpty(name), "name is null or empty");
            DomainValidation.Check(name.Length < 3, "name requires at least 3 characters");

            DomainValidation.Check(string.IsNullOrEmpty(description), "description is null or empty");
            DomainValidation.Check(name.Length < 3, "description requires at least 3 characters");

            DomainValidation.Check(price < 0, "the price had a negative value");
        }
    }
}
