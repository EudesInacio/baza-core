using BazarCore.Entities;
using BazarCore.Models.DTO;
using BazarCore.Services;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.API
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;

        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ResultService<PaginatedList<EventItemDTO>>>> GetAll(int pageIndex, int pageSize)
        {
            var result = await _service.GetAllUpcomeEvents(pageIndex, pageSize);
            return StatusCode((int)result.Status, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultService<Event>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return StatusCode((int)result.Status, result);
        }

        [HttpPost]
        public async Task<ActionResult<ResultService<Event>>> Create(Event entity)
        {
            var result = await _service.AddAsync(entity);
            return StatusCode((int)result.Status, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultService<Event>>> Update(int id, Event entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("The Id in the URL must match the Id in the request body.");
            }

            var result = await _service.UpdateAsync(entity);
            return StatusCode((int)result.Status, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultService<Event>>> Delete(int id)
        {
            var result = await _service.SoftDeleteAsync(id);
            return StatusCode((int)result.Status, result);
        }
    }
}
