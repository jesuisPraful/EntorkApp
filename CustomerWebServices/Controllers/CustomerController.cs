using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerDAL;
using CustomerDAL.Models;

namespace CustomerWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        

        [HttpGet]
        public JsonResult GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                CustomerRepository Repository = new CustomerRepository();
                customers = Repository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                customers = null;
            }
            return Json(customers);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Models.Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerRepository Repository= new CustomerRepository();
                    Customer customerObj = new Customer();
                    customerObj.CustomerId = customer.CustomerId;
                    customerObj.CustomerName = customer.CustomerName;
                    customerObj.CustomerAddress = customer.CustomerAddress;
                    customerObj.CustomerPhone = customer.CustomerPhone;
                    int result = Repository.UpdateCustomerDetails(customerObj);
                    if (result > 0)
                        return Ok("Customer details updated successfully!");
                    else
                        return NotFound("Customer details not updated!");
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
    }
}
