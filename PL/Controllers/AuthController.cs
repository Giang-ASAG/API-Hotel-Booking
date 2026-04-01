using AutoMapper;
using DH52110843_BLL.DTO;
using DH52110843_BLL.UnitOfWork;
using DH52110843_DAL.Data;
using DH52110843_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly string _jwtSecret = "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF";
        //private readonly int _jwtLifespan = 3600;
        private readonly JwtClass _jwt;
        private readonly HethonghotelContext db;
        private IMapper mapper;
        private readonly IUnitOfWork _service;
        public AuthController(HethonghotelContext db,IMapper mapper, IOptions<JwtClass> jwt, IUnitOfWork service)
        {
            this.db = db;
            this.mapper = mapper;
            _jwt = jwt.Value;
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegiterDTO model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Username and password = null");
            }
            if (db.Users.Any(u => u.Email == model.Email))
            {
                return BadRequest("Email exist");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var u = new UserDTO {
                Email = model.Email,
                Password = passwordHash,
                UserRoleId = 2,
                Active = false,
                CreationDate = DateTime.Now,
            };
            db.Users.Add(mapper.Map<User>(u));
            await db.SaveChangesAsync();
            return Ok("Succesfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginDTO model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Username và password = null");
            }
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Unauthorized("Username or password wrong");
            }
            var temp= mapper.Map<UserDTO>(user);
            // Tạo JWT token
            var token = GenerateJwtToken(temp);
            return Ok(new { Token = token, time = _jwt.Lifespan});
        }
        private string GenerateJwtToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);

            var claims = new List<Claim>
            {
                new Claim("id", user.UserId.ToString()),
                //new Claim("name", user.FullName),
                //new Claim("email", user.Email),
                //new Claim("address", user.Address),
                //new Claim("phone", user.PhoneNumber),
                //new Claim("role", user.UserRoleId.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        [HttpPut("check-Email/{email}")]
        public async Task<IActionResult> checkEmail(string email)
        {
            var u = await _service.userService.FindUserByEmailAsync(email);
            if(u == null)
            {
                return Ok(new { message = "Email chua ai su dung" });
            }
            else
            {
                return BadRequest(new { message = "Email da co ng su dung" });
            }
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> sendOTP(string email)
        {
            //var user = _service.userService.FindUserByEmailAsync(email);
            var otp = new Random().Next(10000, 99999).ToString();
            var time = DateTime.UtcNow.AddMinutes(5);

            OtpMemoryStore.MemoryStore[email] = new OtpStore
            {
                Code = otp,
                Time = time
            };
            var body = $"Mã OTP của bạn là: <b>{otp}</b>. Có hiệu lực trong 5v phút.";
            await _service.emailService.SendEmailAsync(email, "OTP",body);

            return Ok(new { message = " OTP send to Email"});
        }
        [HttpPost("verify-otp")]
        public async Task<IActionResult> verifyOTP(OtpVerifyRequest request)
        {
            if (!OtpMemoryStore.MemoryStore.TryGetValue(request.Email, out var entry))
                return BadRequest("OTP không hợp lệ hoặc đã hết hạn.");

            if (entry.Time < DateTime.UtcNow || entry.Code != request.Otp)
                return BadRequest("OTP sai hoặc hết hạn.");

            // Xóa OTP sau khi dùng
            OtpMemoryStore.MemoryStore.TryRemove(request.Email, out _);

            return Ok(new { message = "OTP xác thực thành công!" });
        }


        [HttpPost("sendtoHost")]
        public async Task<IActionResult> sendtoHost(int id)
        {
            var user = await _service.userService.findUserbyId(id);
            if (user != null)
            {
                var info = await _service.userDocumentService.getbyUserId(id);
                var email = "anhrutro@gmail.com";
                var approveLink = $"https://localhost:7267/approve-permission/{id}";
                // Gửi HTML email
                var body = $@"
                                <h3>Khách hàng đăng ký trở thành đối tác:</h3>
                                <ul>
                                    <li><strong>Họ tên:</strong> {user.FullName}</li>
                                    <li><strong>Email:</strong> {user.Email}</li>
                                    <li><strong>SĐT:</strong> {user.PhoneNumber}</li>
                                    <li><strong>CCCD:</strong> {info.CccdNumber}</li>
                                    <li><strong>Mã số thuế:</strong> {info.TaxCode ?? "(Không có)"}</li>
                                    <li><strong>Số tài khoản:</strong> {info.BankAccountNumber}</li>
                                    <li><strong>Ngân hàng:</strong> {info.BankName}</li>
                                </ul>
                                <p><a href='{approveLink}' style='color:green;font-weight:bold;'>Bấm vào đây để duyệt tài khoản</a></p>
                            ";
                await _service.emailService.SendEmailWithAttachment(email, $"Khách hàng muốn trở thành đối tác của bạn.", body, info.ImageBase64,"gpkd.png");
                return Ok(new { message = " Send to Host" });
            }
            return BadRequest("Khong co user");

        }


        [HttpPost("sendtoUser")]
        public async Task<IActionResult> sendtoUser(string email)
        {
            var body = $"Bạn đã được phê duyệt thành công, bạn đã trở thành đối tác";
            await _service.emailService.SendEmailAsync(email, $"Đơn của bạn đã được duyệt", body);
            return Ok(new { message = " Đã gửi" });
        }
        [HttpPost("sendtoUserFail")]
        public async Task<IActionResult> sendtoUserFail(string email)
        {
            var body = $"Quản trị đã từ chối đơn duyệt của bạn, vui lòng nhập lại thông tin!!";
            await _service.emailService.SendEmailAsync(email, $"Từ chối trở thành đối tác", body);
            return Ok(new { message = " Đã gửi" });
        }



        [HttpPut("change-password")]
        public async Task<IActionResult> changePassword(int id, PasswordDTO password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password.beforePassword, user.Password))
            {
                return BadRequest("Username or password wrong");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password.afterPassword);
            user.Password = passwordHash;
            await db.SaveChangesAsync();
            return Ok("ChangePassword Succes");
        }
        [HttpPut("forget-password")]
        public async Task<IActionResult> forgetPassword(string email,[FromBody] string password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return Unauthorized("User is null");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password = passwordHash;
            await db.SaveChangesAsync();
            return Ok("ChangePassword Succes");
        }
        [HttpPost]
        public async Task<IActionResult> test()
        {
            foreach (var item in db.Rooms.ToList())
            {
                item.Status = false;
            }
            await db.SaveChangesAsync();
            return Ok("ChangePassword Succes");
        }

    }















    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
    }
    public class RegiterDTO
    {

        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }


    }
    public class PasswordDTO
    {
        [Required]
        public string? beforePassword { get; set; }
        [Required]
        public string? afterPassword { get; set; }

    }
}
