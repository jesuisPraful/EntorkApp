using CustomerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDAL
{
    public class CustomerRepository
    {
        public EntorkCustomerDbContext Context { get; set; }
        public CustomerRepository()
        {
            Context = new EntorkCustomerDbContext();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = Context.Customers.ToList();
            }
            catch (Exception ex)
            {
                customers = null;
            }
            return customers;
        }


        public int UpdateCustomerDetails(Customer customer)
        {
            int result = 0;
            try
            {
                Customer existingCustomer = Context.Customers
                    .Where(c => c.CustomerId == customer.CustomerId).FirstOrDefault();
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerAddress = customer.CustomerAddress;
                    existingCustomer.CustomerPhone = customer.CustomerPhone;
                    Context.SaveChanges();
                    result = 1;
                }
                else
                {
                    result = -1;
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
    }
}
