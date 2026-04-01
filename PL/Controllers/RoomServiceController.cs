using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomServiceController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        public RoomServiceController(IUnitOfWork repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRoomService() {
            return Ok(await _repository.roomService_Service.getAllAsync());
        }
        [HttpGet("getAllbyRoomTypeId")]
        public async Task<IActionResult> getAllbyRoomTypeId(int id)
        {
            return Ok(await _repository.roomService_Service.getAllbyRoomTypeIdAsync(id));
        }
        [HttpGet("getAllbyUserId/{id}")]
        public async Task<IActionResult> getAllbyUserId(int id)
        {
            return Ok(await _repository.roomService_Service.getAllbyRoomSeviceUserIdAsync(id));
        }
        [HttpPost("addRoomService")]
        [Authorize]
        public async Task<IActionResult> addRoomService(RoomServiceDTO roomService)
        {
            if (roomService == null) return BadRequest("roomService = null");
            await _repository.roomService_Service.addAsync(roomService);
            return Ok("Add roomService succesfully");
        }
        [HttpPut("updateRoomService/{id}")]
        [Authorize]
        public async Task<IActionResult> updateRoomService(int id,RoomServiceDTO roomService)
        {
            if (id <= 0) return BadRequest("id <=0 ");
            await _repository.roomService_Service.updateAsync(id, roomService);
            return Ok("update RoomService succesfully");
        }
        [HttpDelete("deleteRoomService/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteRoomService(int id)
        {
            if (id <= 0) return BadRequest("id <=0 ");
            await _repository.roomService_Service.deleteAsync(id);
            return Ok("delete RoomService succesfully");
        }
        [HttpGet("updateRoomService/{id}")]
        public async Task<IActionResult> findByIdAsync(int id)
        {
            if (id <= 0) return BadRequest("id <=0 ");
            return Ok(await _repository.roomService_Service.findByIdAsync(id));
        }
    }
}
