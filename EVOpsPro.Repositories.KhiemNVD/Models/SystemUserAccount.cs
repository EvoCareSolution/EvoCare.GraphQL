using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.Models;

public partial class SystemUserAccount
{
    public int UserAccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string EmployeeCode { get; set; } = null!;

    public int RoleId { get; set; }

    public string? RequestCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ApplicationCode { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }
    
    public virtual ICollection<AppointmentTrungDn> AppointmentTrungDns { get; set; } = new List<AppointmentTrungDn>();

    public virtual ICollection<MaintenanceProcessVietHq> MaintenanceProcessVietHqs { get; set; } = new List<MaintenanceProcessVietHq>();

    public virtual ICollection<PartDuongNm> PartDuongNms { get; set; } = new List<PartDuongNm>();

    public virtual ICollection<ReminderKhiemNvd> ReminderKhiemNvds { get; set; } = new List<ReminderKhiemNvd>();

    public virtual ICollection<TechnicianKhoaPa> TechnicianKhoaPas { get; set; } = new List<TechnicianKhoaPa>();

    public virtual ICollection<WorkOrderTienHn> WorkOrderTienHns { get; set; } = new List<WorkOrderTienHn>();

}
