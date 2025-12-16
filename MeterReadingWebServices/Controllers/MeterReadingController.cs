using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MeterReadingDAL;
using MeterReadingDAL.Models;

namespace MeterReadingWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : Controller
    {
        public  MeterReadingRepository Repository { get; set; }
        public MeterReadingController(MeterReadingRepository repository)
        {
            Repository = repository;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetReadingsForCustomers(int customerId)
        {
            List<Models.MeterReading> readings = new List<Models.MeterReading>();
            try
            {
                var readingsList = Repository.GetReadingsForCustomer(customerId);
                if (readingsList != null)
                {
                    foreach (var reading in readingsList)
                    {
                        Models.MeterReading readingObj = new Models.MeterReading();
                        readingObj.MeterReadingId = reading.MeterReadingId;
                        readingObj.CustomerId = reading.CustomerId;
                        readingObj.ReadingDate = reading.ReadingDate;
                        readingObj.ReadingValue = reading.ReadingValue;
                        readings.Add(readingObj);
                    }
                    return Ok(readings);
                }
                else
                {
                    return NotFound("Readings not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public JsonResult AddMeterReading(Models.MeterReading reading)
        {
            try
            {
                MeterReading readingObj = new MeterReading();
                readingObj.CustomerId = reading.CustomerId;
                readingObj.ReadingValue = reading.ReadingValue;

                bool result = Repository.AddMeterReading(readingObj);
                if (result)
                    return Json("Reading added successfully!");
                else
                    return Json("Reading not added!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


    }
}
