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
    public class RoomTypeController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public RoomTypeController(IUnitOfWork service)
        {
            _service= service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoomType() { 
            return Ok(await _service.roomTypeService.getAllRoomTypeAsync());
        }
        
        [HttpGet("getAllRoomTypebyHotelId/{id}")]
        public async Task<IActionResult> getAllRoomTypebyHotelIdAsync(int id)
        {
            return Ok(await _service.roomTypeService.getAllRoomTypebyHotelIdAsync(id));
        }
        [HttpGet("getAllRoomTypeAndCount/{id}")]
        public async Task<IActionResult> getAllRoomTypeAndCount(int id)
        {
            var list = await _service.roomTypeService.getAllRoomTypeAndCount(id);
            foreach (var item in list)
            {
                var url = await _service.roomImageService.getAllImagebyRoomIdAsync(item.RoomTypeId);
                foreach (var i in url)
                {
                    var img = await _service.roomImagesStorageService.findAsync(i.ImageId);
                    item.imgPath.Add(img.ImagePath);
                }
                
            }
            return Ok(list);
        }
        [HttpPost("getAllRoomTypeAndCountbySreach")]
        public async Task<IActionResult> getAllRoomTypeAndCount(RoomTypeSearchRequest request)
        {
            var list = await _service.roomTypeService.getAllRoomTypebySearch(request);
            foreach (var item in list)
            {
                var url = await _service.roomImageService.getAllImagebyRoomIdAsync(item.RoomTypeId);
                foreach (var i in url)
                {
                    var img = await _service.roomImagesStorageService.findAsync(i.ImageId);
                    item.imgPath.Add(img.ImagePath);
                }

            }
            return Ok(list);
        }

        [HttpGet("getAllRoomTypebyUserId/{id}")]
        public async Task<IActionResult> getAllRoomTypebyUserIdAsync(int id)
        {
            return Ok(await _service.roomTypeService.getAllRoomTypebyUserIdAsync(id));
        }
        [HttpGet("getRoomTypebyId/{id}")]
        public async Task<IActionResult> findRoomTypebyId(int id) {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }


            return Ok(await _service.roomTypeService.findAsync(id));
        }


        [HttpPost("addRoomType")]
        //[Authorize]
        public async Task<IActionResult> addRoomType(RoomTypeDTO roomType)
        {
            var r = await _service.roomTypeService.addAsync(roomType);
            return Ok(r);
        }
        [HttpDelete("deleteRoomType")]
        [Authorize]
        public async Task<IActionResult> deleteRoomType(int id) {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            await _service.roomTypeService.deleteAsync(id);
            return Ok("Delete roomtype succesfully");
        }
        [HttpPut("getRoomTypebyId/{id}")]
        [Authorize]
        public async Task<IActionResult>updateRoomType(int id, RoomTypeDTO roomType)
        {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            await _service.roomTypeService.updateAsync(id, roomType);
            return Ok("Update Roomtype succesfully");
        }
    }
}
