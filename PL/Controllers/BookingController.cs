using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public BookingController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllfromManagerid(int id) {
            return Ok(await _service.bookingService.getAllfromManager(id));
        }
        [HttpGet("GetAllbyHotelID/{id}")]
        public async Task<IActionResult> GetAllbyHotelID(int id)
        {
            var list = await _service.bookingService.getAllbyHotelID(id);
            foreach (var item in list)
            {
                var r = await _service.roomService.findByIdBookingAsync(item.BookingId);
                if (r != null)
                {
                    var rt = await _service.roomTypeService.findAsync(r.RoomTypeId);
                    item.RoomTypeId = rt.RoomTypeId;
                }

            }
            return Ok(list) ;

        }
        [HttpGet("getAllbyUser/{id}")]
        public async Task<IActionResult> getAllbyUser(int id)
        {
            var list = await _service.bookingService.getAllbyUser(id);
            if(list == null)
            {
                return Ok();
            }
            else
            {
                foreach (var item in list)
                {
                    var r = await _service.roomService.findByIdBookingAsync(item.BookingId);
                    if (r != null)
                    {
                        var rt = await _service.roomTypeService.findAsync(r.RoomTypeId);
                        item.HotelId = rt.HotelId;
                        item.RoomTypeId = rt.RoomTypeId;
                    }

                }
                return Ok(list);
           }
        }
        [HttpPost]
        public async Task<IActionResult>addBooking([FromBody]BookingDTO dTO)
        {
            var book = await _service.bookingService.addAsync(dTO);
            return Ok(book);
        }
        [HttpPost("addBookingRoom")]
        public async Task<IActionResult> addBookingRoom([FromBody]BookingRoomDTO dTO)
        {
            var result = await _service.bookingService.addBookingRoomAsync(dTO);
            return Ok(result);
        }
        [HttpGet("getBookingRoom/{id}")]
        public async Task<IActionResult> getBookingRoom(int id)
        {
            var result = await _service.bookingService.GetBookingroomsbyIDBooking(id);
            return Ok(result);
        }
        [HttpPut("cancelBooking/{id}")]
        public async Task<IActionResult> cancelBooking(int id)
        {
            await _service.bookingService.deleteBookingRoom(id);
            return Ok("Delete Succesfully");

        }
        [HttpPut("updateStatus")]
        public async Task<IActionResult> updateStatus(int id, int num)
        {
            var res = await _service.bookingService.updateStatusBooking(id, num);
            if(res)
                return Ok("update Succesfully");
            else return BadRequest();

        }
    }
}
