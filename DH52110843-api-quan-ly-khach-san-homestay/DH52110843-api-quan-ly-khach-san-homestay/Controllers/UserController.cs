using DH52110843_BLL.DTO;
using DH52110843_BLL.Interfaces;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public UserController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.userService.getAllAsync();
            return Ok(users);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            if(user == null)
            {
                return BadRequest("User = null");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var u = new UserDTO
            {
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                Password = passwordHash,
                PhoneNumber = user.PhoneNumber,
                UserRoleId = user.UserRoleId,
                CreationDate = DateTime.Now,
            };
            await _service.userService.AddAsync(u);
            return Ok("User added successfully");
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            if (id <= 0)
            {
                return BadRequest("Id User not found");
            }
            await _service.userService.DeleteAsync(id);
            return Ok("User deleted");
        }
        [HttpPut("GetUserbyId/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserNoPasswordDTO user)
        {
            if (id <= 0)
            {
                return BadRequest("Id User not found");
            }
            await _service.userService.UpdateAsync(id, user);
            return Ok(user);
        }
        [HttpGet("GetUserbyId/{id}")]
        public async Task<IActionResult> FindUserbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id User not found");
            }
            return Ok(await _service.userService.findUserbyId(id));
        }
        [HttpPut("UpdatePermission/{id}")]
        public async Task<IActionResult> UpdatePermission(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id User not found");
            }
            await _service.userService.UpdatePermissionAsync(id);
            return Ok("UpdatePermission succesfully");
        }
        [AllowAnonymous]
        [HttpGet("GetUserCount")]
        public async Task<IActionResult> GetUserCountsByMonth()
        {
            return Ok(await _service.userService.GetUserCountsByMonth());
        }
        [HttpPut("Active")]
        public async Task<IActionResult>activeUser(int id, bool active)
        {
            await _service.userService.ActiveAsync(id, active);
            return Ok("Active succesfully");
        }

    }
}
