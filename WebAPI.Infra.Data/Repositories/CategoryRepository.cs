using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Data.Context;

namespace WebAPI.Infra.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
