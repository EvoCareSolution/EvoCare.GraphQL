using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.GraphQLWebAPI.KhiemNVD.GraphQLs.Inputs;

public class ReminderKhiemNvdInput
{
    public int? ReminderKhiemNvdid { get; set; }
    public int UserAccountId { get; set; }
    public int ReminderTypeKhiemNvdid { get; set; }
    public string VehicleVin { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public int? DueKm { get; set; }
    public string? Message { get; set; }
    public bool IsSent { get; set; }
    public bool IsActive { get; set; } = true;

    public ReminderKhiemNvd ToEntity()
    {
        return new ReminderKhiemNvd
        {
            ReminderKhiemNvdid = ReminderKhiemNvdid ?? 0,
            UserAccountId = UserAccountId,
            ReminderTypeKhiemNvdid = ReminderTypeKhiemNvdid,
            VehicleVin = VehicleVin,
            DueDate = DueDate,
            DueKm = DueKm,
            Message = Message,
            IsSent = IsSent,
            IsActive = IsActive
        };
    }
}
