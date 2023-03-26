//using BazarCore.Entities;
//using BazarCore.Models;
//using BazarCore.Models.DTO;
//using BazarCore.Services;
//using BazarCore.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace BazarCore.Areas.API
//{
//    [ApiController]
//    [Route("v1/api/[controller]")]
//    public class OrganizersController : ControllerBase
//    {
//        private readonly IOrganizerService _service;

//        public OrganizersController(IOrganizerService service)
//        {
//            _service = service;
//        }

//        //[HttpGet]
//        //public async Task<ActionResult<ResultService<PaginatedList<OrganizerItemDTO>>>> GetAll(int pageIndex, int pageSize)
//        //{
//        //    var result = await _service.GetAllActiveOrganizers(pageIndex, pageSize);
//        //    return StatusCode((int)result.Status, result);
//        //}

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ResultService<Organizer>>> GetById(int id)
//        {
//            var result = await _service.GetByIdAsync(id);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<ResultService<Organizer>>> Create(Organizer entity)
//        {
//            var result = await _service.AddAsync(entity);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<ResultService<Organizer>>> Update(int id, Organizer entity)
//        {
//            if (id != entity.UserId)
//            {
//                return BadRequest("The Id in the URL must match the Id in the request body.");
//            }

//            var result = await _service.UpdateAsync(entity);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ResultService<Organizer>>> Delete(int id)
//        {
//            var entity = await _service.GetByIdAsync(id);
//            if (entity == null)
//            {
//                return NotFound($"The entity with Id={id} was not found.");
//            }

//            var result = await _service.DeleteAsync(entity.Data);
//            return StatusCode((int)result.Status, result);
//        }
//    }
//}
