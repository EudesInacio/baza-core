using BazarCore.Entities;
using BazarCore.Services.Interfaces;
using static BazarCore.Models.DTO.UserDTO;
using System.Net;
using BazarCore.Utils.Security;
using BazarCore.Data.Repository.Interfaces;
using BazarCore.Services.Validators;
using BazarCore.Models.DTO;
using FluentValidation;

namespace BazarCore.Services
{
    public class UserService : BaseService<User, UserValidator>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;
        delegate Task SendConfirmationEmail(string email, string token);
        public UserService(IConfiguration configuration, IRepository<User> userRepository, UserValidator validator)
            : base(userRepository, validator)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<ResultService<JwtTokenDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var resultService = new ResultService<JwtTokenDTO>();
            var user = await _userRepository.FindAsync(u => u.Username == userLoginDTO.Username);
            if (user == null)
                return resultService.Fail("Invalid username or password", HttpStatusCode.Unauthorized);
            if (!PasswordHelper.VerifyPassword(userLoginDTO.Password, user.Password))
                return resultService.Fail("Invalid username or password",
                    HttpStatusCode.Unauthorized);
            if (!user.EmailConfirmed)
                return resultService.Fail("Email not confirmed", HttpStatusCode.Forbidden);
            var jwtToken = JwtHelper.GenerateJwtToken(user.Id.ToString(), user.Username);
            return resultService.Good(new JwtTokenDTO { AccessToken = jwtToken });
        }
        public async Task<ResultService<UserLoginResultDTO>> Login(UserWebLoginDTO loginDTO)
        {
            var resultService = new ResultService<UserLoginResultDTO>();
            var user = await _userRepository.FindAsync(u => u.Username == loginDTO.Username);
            if (user == null)
                return resultService.Fail("Invalid username or password", HttpStatusCode.Unauthorized);
            if (!PasswordHelper.VerifyPassword(loginDTO.Password, user.Password))
                return resultService.Fail("Invalid username or password",
                    HttpStatusCode.Unauthorized);
            //if (!user.EmailConfirmed)
            //    return resultService.Fail("Email not confirmed", HttpStatusCode.Forbidden);
            var jwtToken = JwtHelper.GenerateJwtToken(user.Id.ToString(), user.Username);
            var result = new UserLoginResultDTO
            {
                Id = user.Id,
                Role = user.Role.ToString(),
                FullName = user.FirstName,
            };
            return resultService.Good(result);
        }
        public async Task<ResultService<User>> CreateUserAsync(RegisterUserDTO userDTO)
        {
            ResultService<User> resultService = new ResultService<User>();
            if (userDTO.Password != userDTO.ConfirmPassword)
                return resultService.Fail("Password don't match");
            if (userDTO.Email != userDTO.ConfirmEmail)
                return resultService.Fail("Email don't match");
            if (!userDTO.AgreeWithTerms)
                return resultService.Fail("User don't agree with terms");

            var user = new User
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                IsActive = true,
                Username = userDTO.Username,
                Password = userDTO.Password
            };
            if (userDTO.IsOrganizer)
            {
                user.Organizer = new Organizer
                {
                    ComercialName = userDTO.OrganizerComercialName,
                };
            }
            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                return resultService.Fail(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var existingUser = await _userRepository.FindAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                return resultService.Fail($"User with username '{user.Username}' already exists.");
            }
            user.Password = PasswordHelper.HashPassword(user.Password);
            await _userRepository.AddAsync(user);
            return resultService.Good(user);
        }


        //public async Task<ResultService> RecoverPassword(UserRecoverPasswordDTO userRecoverPasswordDTO)
        //{
        //    var resultService = new ResultService();

        //    var user = await _userRepository.FindAsync(u => u.Username == userRecoverPasswordDTO.Username);

        //    if (user == null)
        //    {
        //        resultService.Errors = new List<string> { "User not found" };
        //        resultService.Status = HttpStatusCode.NotFound;
        //        return resultService;
        //    }

        //    // generate password reset token and send email to user with link to reset password

        //    resultService.Success = true;
        //    resultService.Status = HttpStatusCode.OK;

        //    return resultService;
        //}

        //    public async Task<ResultService> ResetPassword(UserResetPasswordDTO userResetPasswordDTO)
        //    {
        //        var resultService = new ResultService();

        //        var user = await _userRepository.FindAsync(u => u.ResetPasswordToken == userResetPasswordDTO.Token);

        //        if (user == null)
        //        {
        //            resultService.Errors = new List<string> { "Invalid or expired reset password token" };
        //            resultService.Status = HttpStatusCode.BadRequest;
        //            return resultService;
        //        }

        //        user.Password = PasswordHelper.CreatePasswordHash(userResetPasswordDTO.NewPassword);
        //        user.ResetPasswordToken = null;

        //        await _userRepository.UpdateAsync(user);

        //        resultService.Success = true;
        //        resultService.Status = HttpStatusCode.OK;

        //        return resultService;
        //    }
        //}
    }
}
