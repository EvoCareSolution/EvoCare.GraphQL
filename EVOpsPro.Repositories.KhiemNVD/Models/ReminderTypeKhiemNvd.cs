using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class ReminderTypeKhiemNvd
{
    public int ReminderTypeKhiemNvdid { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsRecurring { get; set; }

    public int? IntervalDays { get; set; }

    public int? IntervalKm { get; set; }

    public bool IsPaymentRelated { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ReminderKhiemNvd> ReminderKhiemNvds { get; set; } = new List<ReminderKhiemNvd>();
}
