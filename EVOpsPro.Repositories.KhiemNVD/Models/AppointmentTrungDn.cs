using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class AppointmentTrungDn
{
    public int AppointmentTrungDnid { get; set; }

    public int UserAccountId { get; set; }

    public string ServiceCenter { get; set; } = null!;

    public string ServiceType { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public int AppointmentStatusTrungDnid { get; set; }

    public string? Notes { get; set; }

    public string? ConfirmedBy { get; set; }

    public DateTime? ConfirmedDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual AppointmentStatusTrungDn AppointmentStatusTrungDn { get; set; } = null!;

    public virtual SystemUserAccount SystemUserAccount { get; set; } = null!;
}
