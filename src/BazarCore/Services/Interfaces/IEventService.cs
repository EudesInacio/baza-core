using BazarCore.Entities;
using BazarCore.Models;
using BazarCore.Models.DTO;

namespace BazarCore.Services.Interfaces
{
    public interface IEventService : IBaseService<Event>
    {
        Task<ResultService<PaginatedList<EventItemDTO>>> GetAllUpcomeEvents(int pageIndex = 1, int pageSize = 50);
        Task<ResultService<PaginatedList<EventItemDTO>>> GetAllEvents(SearchEvents? search = null, bool onlyActives = false, int pageIndex = 1, int pageSize = 50);
        Task<ResultService<EventDetailsDTO>> GetEventDetails(int Id);
        Task<ResultService<Event>> AddAsync(AddEventDTO addEventDTO);
    }
}
