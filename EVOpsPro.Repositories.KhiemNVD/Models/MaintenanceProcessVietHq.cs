using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class MaintenanceProcessVietHq
{
    public int MaintenanceProcessVietHqid { get; set; }

    public int MaintenanceStepVietHqid { get; set; }

    public int? UserAccountId { get; set; }

    public string VehicleVin { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Notes { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual MaintenanceStepVietHq MaintenanceStepVietHq { get; set; } = null!;

    public virtual SystemUserAccount? SystemUserAccount { get; set; }
}
