using BazarCore.Data.Repository.Interfaces;
using BazarCore.Entities;
using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using BazarCore.Services.Validators;
using FluentValidation;
using System.Linq.Expressions;
using System.Net;

namespace BazarCore.Services
{
    public class CategoryService : BaseService<Category, CategoryValidator>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, CategoryValidator validator) : base(repository, validator)
        {
        }
        public async Task<ResultService<List<CategoryDTO>>> GetAllActiveCategories()
        {
            var result = new ResultService<List<CategoryDTO>>();

            try
            {
                Expression<Func<Category, bool>> filter = x => !x.IsDeleted && x.IsActive;
                Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy =
                    x => x.OrderByDescending(x => x.CreatedAt);
                Expression<Func<Category, CategoryDTO>> select = x => new CategoryDTO(x);
                var include = new List<string> { "CategorySections" };
                var entities = await _repository.GetAllAsync(select, include, filter, orderBy);
                result.Data = entities;
                result.Success = true;
                result.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Errors = new List<string> { ex.Message };
                result.Success = false;
                result.Status = HttpStatusCode.InternalServerError;
            }

            return result;
        }
    }
}
