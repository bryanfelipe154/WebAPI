using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Data.Context;

namespace WebAPI.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
