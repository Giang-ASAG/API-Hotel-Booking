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
    public class HotelImageController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public HotelImageController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllImageHotel() {
            return Ok(await _service.hotelImageService.GetAllHotelImagesAsync());
        }
        [HttpGet("getImagebyIdHotel/{id}")]
        public async Task<IActionResult> GetImagebyIdHotel(int id) {
            return Ok(await _service.hotelImageService.GetImagesByIdHotel(id));
        }
        [HttpDelete("deleteImageHotel/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            await _service.hotelImageService.deleteAsync(id);
            return Ok("Delete image succesfully");
        }
        [HttpPost("addImageHotel")]
        [Authorize]
        public async Task<IActionResult> addImageHotel(HotelImageDTO image)
        {
            if(image == null)
            {
                return BadRequest("Image hotel = null");
            }
            await _service.hotelImageService.addAsync(image);
            return Ok("Add image hotel succesfully");
        }
        [HttpPut("updateImageHotel/{id}")]
        [Authorize]
        public async Task<IActionResult> updateImageHotel(int id , HotelImageDTO image) { 
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            await _service.hotelImageService.UpdateAsync(id, image);
            return Ok("Update succesfully");
        }
    }
}
