using EVOpsPro.Repositories.KhiemNVD;
using EVOpsPro.Repositories.KhiemNVD.ModelExtensions;
using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.Servcies.KhiemNVD;

public class ReminderKhiemNvdService : IReminderKhiemNvdService
{
    private readonly IUnitOfWork _unitOfWork;
    public ReminderKhiemNvdService() => _unitOfWork = new UnitOfWork();

    public Task<List<ReminderKhiemNvd>> GetAllAsync(ReminderSearchRequest? request = null)
        => _unitOfWork.ReminderRepository.GetAllAsync(request);

    public Task<PaginationResult<List<ReminderKhiemNvd>>> SearchWithPagingAsync(ReminderSearchRequest request)
        => _unitOfWork.ReminderRepository.SearchWithPagingAsync(request);

    public Task<ReminderKhiemNvd?> GetByIdAsync(int id)
        => _unitOfWork.ReminderRepository.GetByIdAsync(id);

    public async Task<int> CreateAsync(ReminderKhiemNvd entity)
    {
        entity.CreatedDate ??= DateTime.UtcNow;
        entity.ModifiedDate ??= entity.CreatedDate;
        entity.IsActive = true;
        entity.IsSent = entity.IsSent && entity.DueDate <= DateTime.UtcNow;

        return await _unitOfWork.ReminderRepository.CreateAsync(entity);
    }

    public async Task<int> UpdateAsync(ReminderKhiemNvd entity)
    {
        var existing = await GetByIdAsync(entity.ReminderKhiemNvdid);
        if (existing == null)
        {
            return 0;
        }

        existing.ReminderTypeKhiemNvdid = entity.ReminderTypeKhiemNvdid;
        existing.UserAccountId = entity.UserAccountId;
        existing.VehicleVin = entity.VehicleVin;
        existing.DueDate = entity.DueDate;
        existing.DueKm = entity.DueKm;
        existing.Message = entity.Message;
        existing.IsSent = entity.IsSent;
        existing.IsActive = entity.IsActive;
        existing.ModifiedDate = DateTime.UtcNow;

        return await _unitOfWork.ReminderRepository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reminder = await GetByIdAsync(id);
        if (reminder == null)
        {
            return false;
        }

        reminder.IsActive = false;
        reminder.ModifiedDate = DateTime.UtcNow;
        await _unitOfWork.ReminderRepository.UpdateAsync(reminder);
        return true;
    }

    public Task<bool> MarkAsSentAsync(int id, DateTime? sentAtUtc = null)
        => _unitOfWork.ReminderRepository.MarkAsSentAsync(id, sentAtUtc);
}
