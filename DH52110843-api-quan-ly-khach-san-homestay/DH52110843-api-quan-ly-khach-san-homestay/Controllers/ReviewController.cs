using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public ReviewController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> getAllReviews()
        {
            return Ok(await _service.reviewService.getAllAsync());
        }
        [HttpGet("getAllReviewbyHotelId/{id}")]
        public async Task<IActionResult> getAllReviewbyHotelId(int id)
        {
            var list = await _service.reviewService.getAllbyHotelIdAsync(id);
            foreach (var item in list)
            {
                var u = await _service.userService.findUserbyId(item.UserId);
                item.Username = u.FullName;
            }
            return Ok(list);
        }
        [HttpPost("addReview")]
        [Authorize]
        public async Task<IActionResult>addReview(ReviewDTO review)
        {
            if (review == null) return BadRequest("Review = null");
            await _service.reviewService.addAsync(review);
            return Ok("Add review succesfully");
        }
        [HttpDelete("deleteReview/{id}")]
        [Authorize]
        public async Task<IActionResult> deleteReview(int id)
        {
            if (id <= 0) return BadRequest("id <= 0");
            await _service.reviewService.deleteAsync(id);
            return Ok("delete Review "+id+ " succesfully");

        }
    }
}
