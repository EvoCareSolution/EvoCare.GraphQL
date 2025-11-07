using EVOpsPro.Repositories.KhiemNVD.ModelExtensions;
using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.Servcies.KhiemNVD;

public interface IReminderKhiemNvdService
{
    Task<List<ReminderKhiemNvd>> GetAllAsync(ReminderSearchRequest? request = null);
    Task<PaginationResult<List<ReminderKhiemNvd>>> SearchWithPagingAsync(ReminderSearchRequest request);
    Task<ReminderKhiemNvd?> GetByIdAsync(int id);
    Task<int> CreateAsync(ReminderKhiemNvd entity);
    Task<int> UpdateAsync(ReminderKhiemNvd entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> MarkAsSentAsync(int id, DateTime? sentAtUtc = null);
}
