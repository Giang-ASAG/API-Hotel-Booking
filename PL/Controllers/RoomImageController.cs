using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using DH52110843_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImageController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public RoomImageController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoomImage() {
            return Ok(await _service.roomImageService.getAllImagesAsync());
        }
        [HttpGet("getAllImagebyTypeRoomId")]
        public async Task<IActionResult> getAllImagebyTypeRoomId(int id)
        {
            return Ok(await _service.roomImageService.getAllImagebyRoomIdAsync(id));
        }
        [HttpGet("getRoomImagebyId/{id}")]
        public async Task<IActionResult> findRoomImagebyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            var r = await _service.roomImageService.findImageAsync(id);
            return Ok(r);
        }
        [HttpPost("addRoomImage")]
        //[Authorize]
        public async Task<IActionResult> addRoomImage(RoomImageDTO roomImage)
        {
            if (roomImage == null)
            {
                return BadRequest("roomImage = null");
            }
            await _service.roomImageService.addAsync(roomImage);
            return Ok("Add roomImage succesfully");
        }
        [HttpPut("getRoomImagebyId/{id}")]
        [Authorize]
        public async Task<IActionResult> updateRoomImage(int id, RoomImageDTO roomImage)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomImageService.updateAsync(id, roomImage);
            return Ok("Update roomImage id: "+ id +" succesfully");
        }
        [HttpDelete("deleteRoomImage/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteRoomImage(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomImageService.deleteAsync(id);
            return Ok("Delete roomImage id: " + id + " succesfully");
        }
    }
}
