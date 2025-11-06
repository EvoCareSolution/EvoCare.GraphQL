using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class PartDuongNm
{
    public int PartDuongNmid { get; set; }

    public int PartCategoryDuongNmid { get; set; }

    public int? UserAccountId { get; set; }

    public string PartCode { get; set; } = null!;

    public string PartName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int MinimumStock { get; set; }

    public string? Supplier { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual PartCategoryDuongNm PartCategoryDuongNm { get; set; } = null!;

    public virtual SystemUserAccount? SystemUserAccount { get; set; }
}
