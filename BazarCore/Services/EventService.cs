using BazarCore.Data.Repository.Interfaces;
using BazarCore.Entities;
using BazarCore.Models;
using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using BazarCore.Services.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;

namespace BazarCore.Services
{
    public class EventService : BaseService<Event, EventValidator>, IEventService
    {
        public EventService(IRepository<Event> repository, EventValidator validator) : base(repository, validator)
        {
        }
        public async Task<ResultService<PaginatedList<EventItemDTO>>> GetAllUpcomeEvents(int pageIndex = 1, int pageSize = 50)
        {
            var result = new ResultService<PaginatedList<EventItemDTO>>();

            try
            {
                Expression<Func<Event, bool>> filter = x => x.IsActive;
                Func<IQueryable<Event>, IOrderedQueryable<Event>> orderBy =
                    x => x.OrderByDescending(x => x.CreatedAt);
                Expression<Func<Event, EventItemDTO>> select = x => new EventItemDTO(x);
                var include = new List<string> { "EventSessions.Tickets", "Category", "City", "Organizer" };
                var entities = await _repository.GetAllAsync(select, include, filter, orderBy, pageIndex, pageSize);
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
        public async Task<ResultService<PaginatedList<EventItemDTO>>> GetAllActiveEvents(SearchEvents? searchEvents = null, int pageIndex = 1, int pageSize = 50)
        {
            var result = new ResultService<PaginatedList<EventItemDTO>>();

            try
            {
                List<Expression<Func<Event, bool>>> filters = new();
                filters.Add(x => x.IsActive);

                if (searchEvents.CategoryId != 0)
                {
                    filters.Add(x => x.CategoryId == searchEvents.CategoryId);
                }

                if (!string.IsNullOrEmpty(searchEvents.Title))
                {
                    filters.Add(x => x.Title.Contains(searchEvents.Title));
                }

                if (searchEvents.EventTimeFilter != EventTimeFilter.AnyTime)
                {
                    DateTime now = DateTime.Now.Date;
                    DateTime endDate = now.AddDays(7);

                    switch (searchEvents.EventTimeFilter)
                    {
                        case EventTimeFilter.Today:
                            filters.Add(x => x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date == now);
                            break;

                        case EventTimeFilter.Tomorrow:
                            filters.Add(x => x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date == now.AddDays(1));
                            break;

                        case EventTimeFilter.ThisWeek:
                            filters.Add(x => x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date >= now &&
                                                      x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date <= endDate);
                            break;

                        case EventTimeFilter.NextWeek:
                            filters.Add(x => x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date > endDate &&
                                         x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date <= endDate.AddDays(7));
                            break;

                        case EventTimeFilter.NextMonth:
                            filters.Add(x => x.EventSessions.OrderByDescending(o => o.StartDate).FirstOrDefault().StartDate.Date > now.AddDays(7));
                            break;
                    }
                    }


                    Func<IQueryable<Event>, IOrderedQueryable<Event>> orderBy =
                        x => x.OrderByDescending(x => x.CreatedAt);
                    Expression<Func<Event, EventItemDTO>> select = x => new EventItemDTO(x);
                    var include = new List<string> { "EventSessions.Tickets", "Category", "City", "Organizer" };

                    var entities = await _repository.GetAllAsync(select, include, filters, orderBy, pageIndex, pageSize);
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

        public async Task<ResultService<EventDetailsDTO>> GetEventDetails(int Id)
        {
            var result = new ResultService<EventDetailsDTO>();

            try
            {
                Expression<Func<Event, bool>> filter = x => x.Id == Id && !x.IsDeleted;
                Func<IQueryable<Event>, IOrderedQueryable<Event>> orderBy =
                    x => x.OrderByDescending(x => x.CreatedAt);
                Expression<Func<Event, EventDetailsDTO>> select = x => new EventDetailsDTO(x);
                var include = new List<string> { "EventSessions.Tickets", "Category", "City", "Organizer" };
                var eventItem = await _repository.FindAsync(select, include, filter);
                result.Data = eventItem;
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
