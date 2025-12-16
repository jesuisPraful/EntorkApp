using System;
using System.Collections.Generic;

namespace BillDAL.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? CustomerId { get; set; }

    public int? ReadingId { get; set; }

    public DateTime? BillDate { get; set; }

    public decimal? BillAmount { get; set; }

    public string? BillStatus { get; set; }
}
