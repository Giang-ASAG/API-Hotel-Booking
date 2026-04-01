using DH52110843_BLL.DTO;
using DH52110843_BLL.Interfaces;
using DH52110843_BLL.UnitOfWork;
using DH52110843_DAL.Data;
using DH52110843_DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        private readonly HethonghotelContext _context;
        public HotelController(IUnitOfWork hotelService, HethonghotelContext context)
        {
            _service = hotelService;
            
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetAllHotels()
        {
            var hotels = await _context.Hotels
                .Include(h => h.HotelImages)
                    .ThenInclude(hi => hi.Image)
                .Include(h => h.HotelServices)
                .ToListAsync();

            var hotelDtos = hotels.Select(h => new HotelDTO
            {
                HotelId = h.HotelId,
                HotelName = h.HotelName,
                Address = h.Address,
                PhoneNumber = h.PhoneNumber,
                Email = h.Email,
                Description = h.Description,
                XCoordinate = h.XCoordinate,
                YCoordinate = h.YCoordinate,
                Status = h.Status,
                ImagePaths = h.HotelImages
                    .Where(hi => hi.Image != null)
                    .Select(hi => hi.Image!.ImagePath)
                    .ToList(),
            }).ToList();

            return Ok(hotelDtos);
        }

        [HttpPost("SreachKS")]
        public async Task<IActionResult> SearchHotel(HotelSearchRequest hotelSearch)
        {
            var list = await _service.hotelService.searchHotel(hotelSearch);
            foreach (var item in list)
            {
                var t = await _service.hotelImageService.GetImagesByIdHotel(item.HotelId);
                foreach (var i in t)
                {
                    var img = await _service.hotelImageStorageService.findAsync(i.ImageId);
                    item.ImagePaths.Add(img.ImagePath);
                }
            }
            return Ok(list);

        }

        [HttpGet("findHotelbyAddres/{address}")]
        public async Task<IActionResult> findHotelbyAddres(string address)
        {
            //string input = HotelRepository.RemoveDiacritics(address);
            //var list = await _service.hotelService.findHotelByIdAdress(input);

            //foreach (var item in list)
            //{
            //   var t = await _service.hotelImageService.GetImagesByIdHotel(item.HotelId);
            //    foreach (var i in t)
            //    {
            //        var img = await _service.hotelImageStorageService.findAsync(i.ImageId);
            //        item.ImagePaths.Add(img.ImagePath);
            //    }
            //}
            //return Ok(list);
            if (string.IsNullOrWhiteSpace(address))
                return BadRequest("Địa chỉ không được để trống.");

            var list = await _service.hotelService.findHotelByIdAdress(address);

            foreach (var item in list)
            {
                var images = await _service.hotelImageService.GetImagesByIdHotel(item.HotelId);
                foreach (var image in images)
                {
                    var img = await _service.hotelImageStorageService.findAsync(image.ImageId);
                    item.ImagePaths.Add(img.ImagePath);
                }
            }

            return Ok(list);
        }


        [HttpGet("getAllHotel")]
        public async Task<IActionResult> GetAllHotel() 
        {
            var list = await _service.hotelService.getAllHotel();
            return Ok(list);
        }
        [HttpGet("getHotelbyIdUser/{id}")]
        public async Task<IActionResult> getHotelbyIdUser(int id)
        {
            var list = await _service.hotelService.getAllHotelByIdUser(id);
            if(list == null)
            {
                return NoContent();
            }
            return Ok(list);
        }
        [HttpPost("AddHotel")]
        //[Authorize]
        public async Task<IActionResult> AddHotel(HotelDTO hotel)
        {
            if(hotel == null)
            {
                return BadRequest("Hotel = null");
            }
            var h =await _service.hotelService.AddAsync(hotel);
            return Ok(h);
        }
        [HttpGet("getHotelbyId/{id}")]
        public async Task<IActionResult> findHotelbyID(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            var hotel = await _service.hotelService.findHotelbyId(id);
            var t = await _service.hotelImageService.GetImagesByIdHotel(id);
            foreach (var i in t)
            {
                var img = await _service.hotelImageStorageService.findAsync(i.ImageId);
                hotel.ImagePaths.Add(img.ImagePath);
            }
  
            return Ok(hotel);
        }
        [HttpDelete("deleteHotel/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteHotel(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            await _service.hotelService.DeleteAsync(id);
            return Ok("Delete hotel succesfully");
        }
        [HttpPut("getHotelbyId/{id}")]
        [Authorize]
        public async Task<IActionResult> updateHotel(int id, HotelDTO hotel)
        {
            if (id <= 0)
            {
                return BadRequest("Id <= 0");
            }
            await _service.hotelService.UpdateAsync(id,hotel);
            return Ok("Update hotel succesfully");
        }
    }
}
