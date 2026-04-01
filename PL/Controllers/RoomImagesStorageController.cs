using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImagesStorageController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public RoomImagesStorageController(IUnitOfWork hotelService)
        {
            _service = hotelService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllRoomImagesStorage()
        {
            return Ok(await _service.roomImagesStorageService.getAllAsync());
        }
        [HttpPost("addRoomImagesStorage")]
        //[Authorize]
        public async Task<IActionResult> addRoomImagesStorage(RoomImageStorageDTO storage)
        {
            if (storage == null) return BadRequest("RoomImagesStorage = null");
            await _service.roomImagesStorageService.addAsync(storage);
            var t = await _service.roomImagesStorageService.findPathAsync(storage.ImagePath);
            return Ok(t);
        }
        [HttpPut("updateRoomImagesStorage/{id}")]
        [Authorize]
        public async Task<IActionResult> updateRoomImagesStorage(int id, RoomImageStorageDTO storage)
        {
            if (id <= 0) return BadRequest("id <= 0");
            await _service.roomImagesStorageService.updateAsync(id, storage);
            return Ok("Update id: " + id + " succesfully");
        }
        [HttpDelete("deleteRoomImagesStorage/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteRoomImagesStorage(int id)
        {
            if (id <= 0) return BadRequest("id <= 0");
            await _service.roomImagesStorageService.deleteAsync(id);
            return Ok("Delete id: " + id + " succesfully");
        }
        [HttpGet("getImageRoombyId/{id}")]
        public async Task<IActionResult>getImage(int id)
        {
            if (id <= 0) return BadRequest("id <= 0");
            return Ok(await _service.roomImagesStorageService.findAsync(id));
        }
    }
}
