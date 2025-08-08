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
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public RoomController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoom() {
            return Ok(await _service.roomService.getAllRoomAsync());
        }
        [HttpGet("getAllRoombyRoomTypeId/{id}")]
        public async Task<IActionResult> GetAllRoomByRoomTypeId(int id) {
            return Ok(await _service.roomService.getAllRoombyRoomTypeIdAsync(id));
        }
        [HttpGet("GetAllRoomByHotelId/{id}")]
        public async Task<IActionResult> GetAllRoomByHotelId(int id)
        {
            return Ok(await _service.roomService.getAllRoombyHotelIdAsync(id));
        }
        [HttpPost("addRoom")]
        [Authorize]
        public async Task<IActionResult> addRoom(RoomDTO room)
        {
            if (room == null)
            {
                return BadRequest("Room = null");
            }
            await _service.roomService.addAsync(room);
            return Ok("add room succesfully");
        }
        [HttpDelete("deleteRoom/{id}")]
       // [Authorize]
        public async Task<IActionResult>deleteRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomService.deleteAsync(id);
            return Ok("Delete room succesfully");
        }
        [HttpGet("getRoombyId/{id}")]
        public async Task<IActionResult> findRoombyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            return Ok(await _service.roomService.findByIdAsync(id));
        }
        [HttpPut("getRoombyId/{id}")]
        //[Authorize]
        public async Task<IActionResult> updateRoom(int id, RoomDTO room)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomService.updateAsync(id, room);
            return Ok("Update room succesfully");
        }
        [HttpPut("updateStatus/{id}")]
        [Authorize]
        public async Task<IActionResult> updateStatus(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomService.updateStatusRoom(id);
            return Ok("Update Status room succesfully");
        }
        [HttpPut("holdRoom/{id}")]
        public async Task<IActionResult> holdRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomService.holdRoom(id);
            return Ok("Status room wait");
        }
        [HttpPut("cancelRoom/{id}")]
        public async Task<IActionResult> cancelRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.roomService.cancelRoom(id);
            return Ok("Status room cancel");
        }
        [HttpGet("RandomRoom")]
        public async Task<IActionResult> getRandomRooms(int id, int count)
        {
            // Lấy tất cả phòng theo ID loại phòng
            var allRooms = await _service.roomService.getAllRoombyRoomTypeIdAsync(id);
            List<RoomDTO> availableRooms = new List<RoomDTO>();

            // Lọc các phòng dựa trên trạng thái
            foreach (var item in allRooms)
            {
                if (item.Status==false && item.Active==true) // Giả sử Status là boolean chỉ định tính khả dụng
                {
                    availableRooms.Add(item);
                }
            }

            // Tùy chọn: ngẫu nhiên và giới hạn số lượng phòng trả về nếu cần
            var randomRooms = availableRooms.OrderBy(r => Guid.NewGuid()).Take(count).ToList();

            return Ok(randomRooms);
        }
    }
}
