using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillDAL;
using BillDAL.Models;

namespace BillWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : Controller
    {
        public BillRepository Repository { get; set; }

        

        [HttpGet("{billId}")]
        public JsonResult GetBillDetails(int billId, BillRepository repository)
        {
            Models.Bill bill = new Models.Bill();
            Repository = repository;
            try
            {
                var billObj = Repository.GetBillDetails(billId);
                if (billObj != null)
                {
                    bill.BillId = billObj.BillId;
                    bill.CustomerId = billObj.CustomerId;
                    bill.ReadingId = billObj.ReadingId;
                    bill.BillDate = billObj.BillDate;
                    bill.BillAmount = billObj.BillAmount;
                    bill.BillStatus = billObj.BillStatus;
                }
            }
            catch (Exception ex)
            {
                bill = null;
            }
            return Json(bill);
        }

        [HttpPost]
        public IActionResult AddBill(Models.Bill bill, BillRepository repository)
        {
            Repository = repository;
            try
            {
                if (ModelState.IsValid)
                {
                    Bill billObj = new Bill();
                    billObj.CustomerId = bill.CustomerId;
                    billObj.ReadingId = bill.ReadingId;
                    billObj.BillAmount = bill.BillAmount;
                    bool result = Repository.AddBill(billObj);
                    if (result)
                        return Ok("Bill added successfully!");
                    else
                        return NotFound("Bill not added!");
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

        [HttpPut("{billId}")]
        public IActionResult PayBill(int billId, BillRepository repository)
        {
            Repository = repository;
            try
            {
                bool result = Repository.PayBill(billId);
                if (result)
                    return Ok("Bill paid successfully!");
                else
                    return NotFound("Bill not paid!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{billId}")]
        public JsonResult DeleteBill(int billId, BillRepository repository)
        {
            Repository = repository;
            try
            {
                bool result = Repository.DeleteBill(billId);
                if (result)
                    return Json("Bill deleted successfully!");
                else
                    return Json("Bill not deleted!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
