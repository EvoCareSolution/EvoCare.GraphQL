using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class ReminderKhiemNvd
{
    public int ReminderKhiemNvdid { get; set; }

    public int UserAccountId { get; set; }

    public int ReminderTypeKhiemNvdid { get; set; }

    public string VehicleVin { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public int? DueKm { get; set; }

    public string? Message { get; set; }

    public bool IsSent { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ReminderTypeKhiemNvd ReminderTypeKhiemNvd { get; set; } = null!;

    public virtual SystemUserAccount SystemUserAccount { get; set; } = null!;
}
