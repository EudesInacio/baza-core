using BazarCore.Entities;
using BazarCore.Models.DTO;

namespace BazarCore.Services.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
        public Task<ResultService<List<CategoryDTO>>> GetAllActiveCategories();
    }
}
