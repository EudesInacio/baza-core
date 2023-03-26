using BazarCore.Entities;
using BazarCore.Models;
using BazarCore.Models.DTO;

namespace BazarCore.Services.Interfaces
{
    public interface IEventService : IBaseService<Event>
    {
        Task<ResultService<PaginatedList<EventItemDTO>>> GetAllUpcomeEvents(int pageIndex = 1, int pageSize = 50);
        Task<ResultService<PaginatedList<EventItemDTO>>> GetAllActiveEvents(SearchEvents? search = null, int pageIndex = 1, int pageSize = 50);
        Task<ResultService<EventDetailsDTO>> GetEventDetails(int Id);
    }
}
