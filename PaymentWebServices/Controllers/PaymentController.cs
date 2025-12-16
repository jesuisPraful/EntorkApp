using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDAL;
using PaymentDAL.Models;

namespace PaymentWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        public PaymentRepository Repository { get; set; }

        public PaymentController(PaymentRepository repository)
        {
            Repository = repository;
        }

        [HttpGet("{billId}")]
        public IActionResult GetPaymentStatus(int billId)
        {
            string status = string.Empty;
            try
            {
                status = Repository.GetPaymentStatus(billId);
                if (status != string.Empty)
                    return Ok(status);
                else
                    return NotFound("Payment status not found!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult AddPayment(Models.Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Payment paymentObj = new Payment();
                    paymentObj.BillId = payment.BillId;
                    paymentObj.PaymentAmount = payment.PaymentAmount;
                    bool result = Repository.AddPayment(paymentObj);
                    if (result)
                        return Ok("Payment added successfully!");
                    else
                        return NotFound("Payment not added!");
                }
                else
                {
                    return BadRequest("Input not in proper format!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{paymentId}")]
        public JsonResult DeletePayment(int paymentId)
        {
            try
            {
                bool result = Repository.DeletePayment(paymentId);
                if (result)
                    return Json("Payment deleted successfully!");
                else
                    return Json("Payment not deleted!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


    }
}
