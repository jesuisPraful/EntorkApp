using MeterReadingDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReadingDAL
{
    public class MeterReadingRepository
    {
        public EntorkMeterReadingDbContext Context { get; set; }
        public MeterReadingRepository()
        {
            Context = new EntorkMeterReadingDbContext();
        }


        public List<MeterReading> GetReadingsForCustomer(int customerId)
        {
            List<MeterReading> readings = new List<MeterReading>();
            try
            {
                readings = Context.MeterReadings
                    .Where(m => m.CustomerId == customerId).ToList();
            }
            catch (Exception ex)
            {
                readings = null;
            }
            return readings;
        }

        public bool AddMeterReading(MeterReading reading)
        {
            bool result = false;
            try
            {
                reading.ReadingDate = DateTime.Now;
                Context.MeterReadings.Add(reading);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
