using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class PartCategoryDuongNm
{
    public int PartCategoryDuongNmid { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int? WarrantyMonths { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<PartDuongNm> PartDuongNms { get; set; } = new List<PartDuongNm>();
}
