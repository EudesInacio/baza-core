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
    public class OrganizerService : BaseService<Organizer, OrganizerValidator>, IOrganizerService
    {
        public OrganizerService(IRepository<Organizer> repository, OrganizerValidator validator) : base(repository, validator)
        {
        }
        //public async Task<ResultService<PaginatedList<OrganizerItemDTO>>> GetAllActiveOrganizers(int pageIndex = 1, int pageSize = 50)
        //{
        //    var result = new ResultService<PaginatedList<OrganizerItemDTO>>();

        //    try
        //    {
        //        Expression<Func<Organizer, bool>> filter = x => !x.IsDeleted;
        //        Func<IQueryable<Organizer>, IOrderedQueryable<Organizer>> orderBy =
        //            x => x.OrderByDescending(x => x.CreatedAt);
        //        Expression<Func<Organizer, OrganizerItemDTO>> select = x => new OrganizerItemDTO(x);
        //        var entities = await _repository.GetAllAsync(select, filter, orderBy, pageIndex, pageSize);
        //        result.Data = entities;
        //        result.Success = true;
        //        result.Status = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Errors = new List<string> { ex.Message };
        //        result.Success = false;
        //        result.Status = HttpStatusCode.InternalServerError;
        //    }

        //    return result;
        //}
    }
}
