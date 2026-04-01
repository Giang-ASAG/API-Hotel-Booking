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
    public class HotelImageStorageController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public HotelImageStorageController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> getAllHotelImageStorage()
        {
            return Ok(await _service.hotelImageStorageService.GetHotelImagesStorageAsync());
        }
        [HttpPost("addHotelImageStorage")]
        //[Authorize]
        public async Task<IActionResult> addHotelImageStorage(HotelImageStorageDTO storageDTO)
        {
            if(storageDTO == null)
            {
                return BadRequest("HotelImageStorage = null");
            }
            var r =await _service.hotelImageStorageService.addAsync(storageDTO);
            return Ok(r);
        }
        [HttpGet("getHotelImageStoragebyId/{id}")]
        public async Task<IActionResult> findHotelImageStoragebyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            return Ok(await _service.hotelImageStorageService.findAsync(id));
        }
        [HttpDelete("deleteHotelImageStorage/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteHotelImageStorage(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.hotelImageService.deleteAsync(id);
            return Ok("Delete succesfully");
        }
        [HttpPut("getHotelImageStoragebyId/{id}")]
        [Authorize]
        public async Task<IActionResult> updateHotelImageStorage(int id, HotelImageStorageDTO storage)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.hotelImageStorageService.updateAsync(id, storage);
            return Ok("Update succesfully");
        }

    }
}
