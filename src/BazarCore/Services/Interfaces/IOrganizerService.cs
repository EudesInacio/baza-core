using BazarCore.Entities;
using BazarCore.Models.DTO;

namespace BazarCore.Services.Interfaces
{
    public interface IOrganizerService : IBaseService<Organizer>
    {   
        Task<ResultService<PaginatedList<OrganizerDTO>>> GetAllOrganizers(int pageIndex = 1, int pageSize = 50);
    }
}
