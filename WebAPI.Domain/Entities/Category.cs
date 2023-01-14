using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Validation;

namespace WebAPI.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Validade(name);

            Name = name;
        }

        private void Validade(string name)
        {
            DomainValidation.Check(string.IsNullOrEmpty(name), "name is null or empty");
            DomainValidation.Check(name.Length < 3, "name requires at least 3 characters");
        }
    }
}
