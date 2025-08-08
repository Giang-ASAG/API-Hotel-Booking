using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDocumentController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public UserDocumentController(IUnitOfWork service)
        {
            _service =service;
        }
        [HttpPost]
        public async Task<IActionResult> addAsync(UserDocumentDTO user)
        {
            var u = await _service.userDocumentService.addAsync(user);
            return Ok(u);
        }
        [HttpGet]
        public async Task<IActionResult> getByUserId(int id)
        {
            var u = await _service.userDocumentService.getbyUserId(id);
            if (u == null)
            {
                return BadRequest("Null");
            }
            return Ok(u);
        }
        [HttpGet("getalluser")]
        public async Task<IActionResult> getAll()
        {
            var u = await _service.userDocumentService.getAllAsync();
            if (u == null)
            {
                return BadRequest("Null");
            }
            return Ok(u);
        }
        [HttpGet("getalldocument")]
        public async Task<IActionResult> getalldocument()
        {
            var u = await _service.userDocumentService.getAllDocumentAsync();
            foreach (var item in u)
            {
                item.ImageBase64 = null;
            }
            if (u == null)
            {
                return BadRequest("Null");
            }
            return Ok(u);
        }
        [HttpPut("updateActive")]
        public async Task<IActionResult> updateActive(int id, int num)
        {
            var result = await _service.userDocumentService.updateActive(id, num);
            if (result)
            {
                if(num == 1)
                {
                    await _service.userService.UpdatePermissionAsync(id);
                    return Ok("Succesfully");
                }
                else
                {
                    return Ok("Unsuccesfully");
                }

            }
            return BadRequest();
        }
    }
}
