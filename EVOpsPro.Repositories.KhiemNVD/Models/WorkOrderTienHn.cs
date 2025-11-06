using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class WorkOrderTienHn
{
    public int WorkOrderTienHnid { get; set; }

    public int WorkOrderChecklistTienHnid { get; set; }

    public int? UserAccountId { get; set; }

    public string? ChecklistResult { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string Status { get; set; } = null!;

    public decimal? TotalCost { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual SystemUserAccount? SystemUserAccount { get; set; }

    public virtual WorkOrderChecklistTienHn WorkOrderChecklistTienHn { get; set; } = null!;
}
