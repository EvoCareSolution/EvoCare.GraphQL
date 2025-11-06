using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class TechnicianKhoaPa
{
    public int TechnicianKhoaPaid { get; set; }

    public int UserAccountId { get; set; }

    public int ShiftKhoaPaid { get; set; }

    public string Specialty { get; set; } = null!;

    public string? Certificate { get; set; }

    public int? ExperienceYears { get; set; }

    public decimal? EfficiencyScore { get; set; }

    public DateTime? HireDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ShiftKhoaPa ShiftKhoaPa { get; set; } = null!;

    public virtual SystemUserAccount SystemUserAccount { get; set; } = null!;
}
