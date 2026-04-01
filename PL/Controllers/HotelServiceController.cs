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
    public class HotelServiceController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public HotelServiceController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelService() 
        {
            var list = await _service.hotelServiceService.getHotelServiceAsync();
            return Ok(list);
        }
        [HttpGet("getHotelServicebyHotelId/{id}")]

        public async Task<IActionResult> getHotelServicebyHotelId(int id)
        {
            var list = await _service.hotelServiceService.getHotelServicebyIdHotelAsync(id);
            return Ok(list);
        }
        [HttpGet("getHotelServicebyUserId/{id}")]

        public async Task<IActionResult> getHotelServicebyUserId(int id)
        {
            var list = await _service.hotelServiceService.getHotelServicebyIdUserAsync(id);
            return Ok(list);
        }
        [HttpGet("gettHotelServicebyId/{id}")]
        public async Task<IActionResult> findtHotelServicebyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            return Ok(await _service.hotelServiceService.findByIdAsync(id));
        }
        [HttpPost("addHotelService")]
        //[Authorize]
        public async Task<IActionResult>addHotelService(HotelServiceDTO hotelService)
        {
            if(hotelService == null)
            {
                return BadRequest("hotelService = null");
            }
            await _service.hotelServiceService.addAsync(hotelService);
            return Ok("Add hotelService succesfully");
        }
        [HttpDelete("deleteHotelService/{id}")]
        //[Authorize]
        public async Task<IActionResult> deleteHotelService(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.hotelServiceService.deleteAsync(id);
            return Ok("deleteHotelService succesfully");
        }
        [HttpPut("gettHotelServicebyId/{id}")]
        //[Authorize]
        public async Task<IActionResult> updateHotelService(int id, HotelServiceDTO hotelService)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.hotelServiceService.updateAsync(id,hotelService);
            return Ok("Update hotelService succesfully");
        }
    }
}
