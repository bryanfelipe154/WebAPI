using WebAPI.Application.DTOs;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application.Interfaces
{
    public interface ICategoryService : IRepositoryBase<CategoryDTO>
    {

    }
}
