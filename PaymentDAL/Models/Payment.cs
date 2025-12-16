using System;
using System.Collections.Generic;

namespace PaymentDAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? BillId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public string? PaymentStatus { get; set; }
}
