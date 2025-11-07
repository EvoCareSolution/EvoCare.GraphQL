using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.Servcies.KhiemNVD;

public interface IReminderTypeKhiemNvdService
{
    Task<List<ReminderTypeKhiemNvd>> GetAllAsync(bool includeInactive = false);
    Task<ReminderTypeKhiemNvd?> GetByIdAsync(int id);
    Task<int> CreateAsync(ReminderTypeKhiemNvd entity);
    Task<int> UpdateAsync(ReminderTypeKhiemNvd entity);
    Task<bool> UpdateStatusAsync(int id, bool isActive);
}
