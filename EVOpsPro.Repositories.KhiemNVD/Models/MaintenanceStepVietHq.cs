using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class MaintenanceStepVietHq
{
    public int MaintenanceStepVietHqid { get; set; }

    public string StepName { get; set; } = null!;

    public string? Description { get; set; }

    public int? EstimatedMinutes { get; set; }

    public bool IsFinalStep { get; set; }

    public int SortOrder { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<MaintenanceProcessVietHq> MaintenanceProcessVietHqs { get; set; } = new List<MaintenanceProcessVietHq>();
}
