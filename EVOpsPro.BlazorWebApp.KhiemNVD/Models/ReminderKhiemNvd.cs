using Newtonsoft.Json;

namespace EVOpsPro.BlazorWebApp.KhiemNVD.Models;

public class ReminderKhiemNvd
{
    public int? ReminderKhiemNvdid { get; set; }
    public int UserAccountId { get; set; }
    public int ReminderTypeKhiemNvdid { get; set; }
    public string VehicleVin { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } = DateTime.Today;
    public int? DueKm { get; set; }
    public string? Message { get; set; }
    public bool IsSent { get; set; }
    public bool IsActive { get; set; } = true;
    public SystemUserAccount? SystemUserAccount { get; set; }
    public ReminderTypeKhiemNvd? ReminderTypeKhiemNvd { get; set; }
}

public class ReminderSearchRequestInput
{
    public int? ReminderTypeId { get; set; }
    public int? UserAccountId { get; set; }
    public DateTime? DueFrom { get; set; }
    public DateTime? DueTo { get; set; }
    public bool? IsSent { get; set; }
    public bool IncludeInactive { get; set; }
    public bool UpcomingOnly { get; set; }
    public bool OnlyOverdue { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class ReminderListGraphQLResponse
{
    [JsonProperty("reminderKhiemNvds")]
    public List<ReminderKhiemNvd> Reminders { get; set; } = new();
}

public class ReminderGraphQLResponse
{
    [JsonProperty("reminderKhiemNvd")]
    public ReminderKhiemNvd? Reminder { get; set; }
}

public class ReminderPagingGraphQLResponse
{
    [JsonProperty("reminderKhiemNvdsWithPaging")]
    public ReminderPagingResult? Result { get; set; }
}

public class ReminderPagingResult
{
    public List<ReminderKhiemNvd> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}

public class ReminderMutationResponse
{
    [JsonProperty("createReminder")]
    public int CreatedId { get; set; }
}

public class ReminderUpdateMutationResponse
{
    [JsonProperty("updateReminder")]
    public int UpdatedId { get; set; }
}

public class ReminderDeleteMutationResponse
{
    [JsonProperty("deleteReminder")]
    public bool Result { get; set; }
}

public class ReminderMarkSentMutationResponse
{
    [JsonProperty("markReminderAsSent")]
    public bool Result { get; set; }
}
