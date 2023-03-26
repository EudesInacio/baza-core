using BazarCore.Entities;
using BazarCore.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static BazarCore.Models.DTO.UserDTO;

namespace BazarCore.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        delegate Task SendConfirmationEmail(string email, string token);
        Task<ResultService<JwtTokenDTO>> Login(UserLoginDTO userLoginDTO);
        Task<ResultService<User>> CreateUserAsync(RegisterUserDTO user);

    }
}
