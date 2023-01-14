using WebAPI.Domain.Validation;

namespace WebAPI.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }

        public ICollection<Product>? Products { get; set; }

        public Category(string name)
        {
            Validade(name);

            Name = name;
        }

        public Category(int id, string name)
        {
            DomainValidation.Check(id < 0, "Invalid Id value.");

            Validade(name);

            Id = id;
            Name = name;
        }

        private void Validade(string name)
        {
            DomainValidation.Check(string.IsNullOrEmpty(name), "name is null or empty");
            DomainValidation.Check(name.Length < 3, "name requires at least 3 characters");
        }
    }
}
