using PaymentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDAL
{
    public class PaymentRepository
    {
        public EntorkPaymentDbContext Context { get; set; }
        public PaymentRepository()
        {
            Context = new EntorkPaymentDbContext();
        }


        public string GetPaymentStatus(int billId)
        {
            string status = string.Empty;
            try
            {
                status = Context.Payments
                    .Where(p => p.BillId == billId)
                    .Select(p => p.PaymentStatus).FirstOrDefault();
            }
            catch (Exception ex)
            {
                status = string.Empty;
            }
            return status;
        }


        public bool AddPayment(Payment payment)
        {
            bool result = false;
            try
            {
                payment.PaymentStatus = "Processed";
                payment.PaymentDate = DateTime.Now;
                Context.Payments.Add(payment);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }




        public bool DeletePayment(int paymentId)
        {
            bool result = false;
            try
            {
                Payment payment = Context.Payments
                    .Where(p => p.PaymentId == paymentId).FirstOrDefault();
                if (payment != null)
                {
                    Context.Payments.Remove(payment);
                    Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
