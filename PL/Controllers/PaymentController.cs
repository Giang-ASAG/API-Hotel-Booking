using DH52110843_BLL.DTO;
using DH52110843_BLL.DTO.VNPay;
using DH52110843_BLL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DH52110843_api_quan_ly_khach_san_homestay.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        public PaymentController(IUnitOfWork service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> getAllPayment()
        {
            return Ok(await _service.paymentService.getAllPaymentAsync());
        }
        [HttpPost("addPayment")]
        public async Task<IActionResult> addPayment([FromBody]PaymentDTO payment) {
            if(payment == null)
            {
                return BadRequest("payment = null");
            }
            await _service.paymentService.addAsync(payment);
            return Ok("Add payment succesfully");
        }
        [HttpGet("getPaymentbyId/{id}")]
        public async Task<IActionResult> findPaymentbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            return Ok(await _service.paymentService.findPaymentbyIdAsync(id));
        }
        [HttpDelete("deletebyId/{id}")]
        public async Task<IActionResult> deletebyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id <= 0");
            }
            else
            {
                await _service.paymentService.deleteAsync(id);
                return Ok("Delete payment succesfully");
            }
        }
        [HttpPost("create-order")]
        public async Task<IActionResult> createOrder([FromBody]VNPayResquest request)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
            var paymentUrl = _service.paymentService.CreatePaymentUrl(request, ipAddress);
            return Ok(new { payment_url = paymentUrl });
        }
        [HttpGet("payment-return")]
        public ContentResult PaymentReturn()
        {
            var responseCode = Request.Query["vnp_ResponseCode"];
            var transactionNo = Request.Query["vnp_TransactionNo"];
            var txnRef = Request.Query["vnp_TxnRef"];
            var bankCode = Request.Query["vnp_BankCode"];
            var amount = Request.Query["vnp_Amount"];
            var orderInfo = Request.Query["vnp_OrderInfo"];
            var paydate = Request.Query["vnp_PayDate"];
            var html = _service.paymentService.GenerateReturnHtml(responseCode, transactionNo, txnRef, bankCode, amount, orderInfo,paydate);
            return Content(html, "text/html");
        }
        [HttpGet("GetPaymentSumByMonth")]
        public async Task<IActionResult> GetPaymentSumByMonth()
        {
            return Ok(await _service.paymentService.GetPaymentSumByMonth());
        }
        [HttpGet("getSumbyUserId/{id}")]
        public async Task<IActionResult>getSumbyUserId(int id)
        {
            var result = await _service.paymentService.GetPaymentSumByUserId(id);
            return Ok(result);
        }
        [HttpGet("getSumbyHotelId/{id}")]
        public async Task<IActionResult> getSumbyHotelId(int id)
        {
            var result = await _service.paymentService.GetPaymentSumByHotelId(id);
            return Ok(result);
        }
    }
}
