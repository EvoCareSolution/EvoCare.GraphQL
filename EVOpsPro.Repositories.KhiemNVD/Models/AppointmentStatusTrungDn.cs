using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class AppointmentStatusTrungDn
{
    public int AppointmentStatusTrungDnid { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsFinalStatus { get; set; }

    public int SortOrder { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AppointmentTrungDn> AppointmentTrungDns { get; set; } = new List<AppointmentTrungDn>();
}
