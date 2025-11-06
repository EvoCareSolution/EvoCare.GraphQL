using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class ShiftKhoaPa
{
    public int ShiftKhoaPaid { get; set; }

    public string ShiftName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsOvernight { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TechnicianKhoaPa> TechnicianKhoaPas { get; set; } = new List<TechnicianKhoaPa>();
}
