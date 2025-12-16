namespace MeterReadingWebServices.Models
{
    public class MeterReading
    {
        public int MeterReadingId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? ReadingDate { get; set; }

        public int? ReadingValue { get; set; }
    }
}
