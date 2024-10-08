using Application.Services;
using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Runtime.CompilerServices;
using web.DTO.User;
using web.Mapper;

namespace web.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly IUserEmailUpdater _userEmailUpdater;

        private readonly IUserPasswordUpdater _userPasswordUpdater;

        private readonly AppDbContext _appDbContext;

        public UserController(IUserService userService, IUserEmailUpdater userEmailUpdater, IUserPasswordUpdater userPasswordUpdater, AppDbContext appDbContext)
        {
            _userService = userService;
            _userEmailUpdater = userEmailUpdater;
            _userPasswordUpdater = userPasswordUpdater;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] AddUserRequest request)
        {
            User userCreated = await _userService.CreateUserAsync(request.Name,
                request.Email,
                request.Password,
                GenderExtension.ToGender(request.Gender));
            
            return CreatedAtAction(nameof(CreateUser), UserMapper.ToDTO(userCreated));
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers(int pageNumber = 1 , int pageSize = 10)
        {
            IEnumerable<User> userList = await _userService.GetUsersAsync(pageNumber, pageSize);

            return Ok(UserMapper.ToDTO(userList));
        }

        [HttpPatch("/{userId}/email")]
        public async Task<ActionResult> UpdateEmail([FromBody] UpdateEmailRequest request, int userId)
        {
            await _userEmailUpdater.UpdateEmail(userId, request.Email);
            return NoContent();
        }

        [HttpPatch("/{userId}/password")]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request, int userId)
        {
            await _userPasswordUpdater.UpdatePassword(userId, request.NewPassword);
            return NoContent();
        }

        [HttpDelete("/{userId}")]
        public async Task<ActionResult> DeleteUser(int  userId)
        {
           await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
