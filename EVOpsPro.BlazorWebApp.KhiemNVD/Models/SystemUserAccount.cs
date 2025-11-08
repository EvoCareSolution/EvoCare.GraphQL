using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVOpsPro.BlazorWebApp.KhiemNVD.Models;

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
}
public class LoginWrapper
{
    public UserDto Login { get; set; }
}

public class UserDto
{
    public int UserAccountId { get; set; }
    public string FullName { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
}

public class SystemUserAccountListResponse
{
    [JsonPropertyName("systemUserAccounts")]
    public List<SystemUserAccount> SystemUserAccounts { get; set; } = new();
}



