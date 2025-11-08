using Newtonsoft.Json;

namespace EVOpsPro.BlazorWebApp.KhiemNVD.Models;

public class ReminderTypeKhiemNvd
{
    public int? ReminderTypeKhiemNvdid { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public int? IntervalDays { get; set; }
    public int? IntervalKm { get; set; }
    public bool IsPaymentRelated { get; set; }
    public bool IsActive { get; set; } = true;
}

public class ReminderTypeListGraphQLResponse
{
    [JsonProperty("reminderTypes")]
    public List<ReminderTypeKhiemNvd> ReminderTypes { get; set; } = new();
}

public class ReminderTypeGraphQLResponse
{
    [JsonProperty("reminderType")]
    public ReminderTypeKhiemNvd? ReminderType { get; set; }
}

public class ReminderTypeMutationResponse
{
    [JsonProperty("createReminderType")]
    public int? CreatedId { get; set; }
}

public class UpdateReminderTypeResponse
{
    [JsonProperty("updateReminderType")]
    public int UpdatedId { get; set; }
}

public class UpdateReminderTypeStatusResponse
{
    [JsonProperty("updateReminderTypeStatus")]
    public bool Result { get; set; }
}
