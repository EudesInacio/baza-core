//using System.Collections.Generic;
//using System.Threading.Tasks;
//using BazarCore.Data.Repository.Interfaces;
//using BazarCore.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace BazarCore.Areas.API.Controllers
//{
//    [ApiController]
//    [Route("v1/api/[controller]")]
//    public abstract class BaseController<T> : ControllerBase where T : class, IEntity
//    {
//        private readonly IBaseService<T> _service;

//        public BaseController(IBaseService<T> service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<ActionResult<ResultService<IEnumerable<T>>>> GetAll()
//        {
//            var result = await _service.GetAllAsync();
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ResultService<T>>> GetById(int id)
//        {
//            var result = await _service.GetByIdAsync(id);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<ResultService<T>>> Create(T entity)
//        {
//            var result = await _service.AddAsync(entity);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<ResultService<T>>> Update(int id, T entity)
//        {
//            if (id != entity.Id)
//            {
//                return BadRequest("The Id in the URL must match the Id in the request body.");
//            }

//            var result = await _service.UpdateAsync(entity);
//            return StatusCode((int)result.Status, result);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ResultService<T>>> Delete(int id)
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