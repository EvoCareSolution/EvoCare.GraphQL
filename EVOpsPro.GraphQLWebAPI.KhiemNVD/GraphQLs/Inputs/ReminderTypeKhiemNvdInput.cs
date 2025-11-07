using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.GraphQLWebAPI.KhiemNVD.GraphQLs.Inputs;

public class ReminderTypeKhiemNvdInput
{
    public int? ReminderTypeKhiemNvdid { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public int? IntervalDays { get; set; }
    public int? IntervalKm { get; set; }
    public bool IsPaymentRelated { get; set; }
    public bool IsActive { get; set; } = true;

    public ReminderTypeKhiemNvd ToEntity()
    {
        return new ReminderTypeKhiemNvd
        {
            ReminderTypeKhiemNvdid = ReminderTypeKhiemNvdid ?? 0,
            TypeName = TypeName,
            Description = Description,
            IsRecurring = IsRecurring,
            IntervalDays = IntervalDays,
            IntervalKm = IntervalKm,
            IsPaymentRelated = IsPaymentRelated,
            IsActive = IsActive
        };
    }
}
