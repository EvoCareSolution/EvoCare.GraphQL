using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class WorkOrderChecklistTienHn
{
    public int WorkOrderChecklistTienHnid { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsMandatory { get; set; }

    public int? EstimatedMinutes { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<WorkOrderTienHn> WorkOrderTienHns { get; set; } = new List<WorkOrderTienHn>();
}
