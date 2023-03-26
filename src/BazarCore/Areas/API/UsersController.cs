using BazarCore.Entities;
using BazarCore.Models.DTO;
using BazarCore.Services;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BazarCore.Models.DTO.UserDTO;

namespace BazarCore.Areas.API
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultService<User>>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return StatusCode((int)result.Status, result);
        }
        [HttpPost("confirm-email")]
        public async Task<ActionResult<ResultService<User>>> ConfirmEmail(User entity)
        {
            var result = await _service.AddAsync(entity);
            return StatusCode((int)result.Status, result);
        }
        [HttpPost("recover-password")]
        public async Task<ActionResult<ResultService<User>>> RecoverPassword(User entity)
        {
            var result = await _service.AddAsync(entity);
            return StatusCode((int)result.Status, result);
        }
        [HttpPost("reset-password")]
        public async Task<ActionResult<ResultService<User>>> Reset(User entity)
        {
            var result = await _service.AddAsync(entity);
            return StatusCode((int)result.Status, result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ResultService<User>>> Login(UserLoginDTO userLoginDTO)
        {
            var result = await _service.Login(userLoginDTO);
            return StatusCode((int)result.Status, result);
        }
        [HttpPost]
        public async Task<ActionResult<ResultService<User>>> Create(RegisterUserDTO entity)
        {
            var result = await _service.CreateUserAsync(entity);
            return StatusCode((int)result.Status, result);
        }
        //[HttpPost("organizer")]
        //public async Task<ActionResult<ResultService<User>>> CreateOrganizer(Organizer entity)
        //{
        //    var result = await _service.CreateUserAsync(entity);
        //    return StatusCode((int)result.Status, result);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultService<User>>> Update(int id, User entity)
        {
            var result = await _service.UpdateAsync(entity);
            return StatusCode((int)result.Status, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultService<User>>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode((int)result.Status, result);
        }
    }
}
