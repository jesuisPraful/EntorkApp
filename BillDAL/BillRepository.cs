using BillDAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillDAL
{
    public class BillRepository
    {
        public EntorkBillDbContext Context { get; set; }
        public BillRepository()
        {
            Context = new EntorkBillDbContext();
        }

        public Bill GetBillDetails(int billId)
        {
            Bill bill = new Bill();
            try
            {
                bill = Context.Bills
                    .Where(b => b.BillId == billId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                bill = null;
            }
            return bill;
        }

        public bool AddBill(Bill bill)
        {
            bool result = false;
            try
            {
                bill.BillStatus = "Unpaid";
                bill.BillDate = DateTime.Now;
                Context.Bills.Add(bill);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool PayBill(int billId)
        {
            bool result = false;
            try
            {
                Bill bill = Context.Bills
                    .Where(p => p.BillId == billId).FirstOrDefault();
                if (bill != null)
                {
                    bill.BillStatus = "Paid";
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

        public bool DeleteBill(int billId)
        {
            bool result = false;
            try
            {
                Bill bill = Context.Bills
                    .Where(b => b.BillId == billId).FirstOrDefault();
                if (bill != null)
                {
                    Context.Bills.Remove(bill);
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
