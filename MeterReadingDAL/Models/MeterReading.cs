using System;
using System.Collections.Generic;

namespace MeterReadingDAL.Models;

public partial class MeterReading
{
    public int MeterReadingId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? ReadingDate { get; set; }

    public int? ReadingValue { get; set; }
}
