using EVOpsPro.Repositories.KhiemNVD;
using EVOpsPro.Repositories.KhiemNVD.Models;

namespace EVOpsPro.Servcies.KhiemNVD;

public class ReminderTypeKhiemNvdService : IReminderTypeKhiemNvdService
{
    private readonly IUnitOfWork _unitOfWork;
    public ReminderTypeKhiemNvdService() => _unitOfWork = new UnitOfWork();

    public Task<List<ReminderTypeKhiemNvd>> GetAllAsync(bool includeInactive = false)
        => _unitOfWork.ReminderTypeRepository.GetAllAsync(includeInactive);

    public Task<ReminderTypeKhiemNvd?> GetByIdAsync(int id)
        => _unitOfWork.ReminderTypeRepository.GetByIdAsync(id);

    public async Task<int> CreateAsync(ReminderTypeKhiemNvd entity)
    {
        entity.CreatedDate ??= DateTime.UtcNow;
        if (!entity.IsRecurring)
        {
            entity.IntervalDays = null;
            entity.IntervalKm = null;
        }

        return await _unitOfWork.ReminderTypeRepository.CreateAsync(entity);
    }

    public async Task<int> UpdateAsync(ReminderTypeKhiemNvd entity)
    {
        var existing = await GetByIdAsync(entity.ReminderTypeKhiemNvdid);
        if (existing == null)
        {
            return 0;
        }

        existing.TypeName = entity.TypeName;
        existing.Description = entity.Description;
        existing.IsRecurring = entity.IsRecurring;
        existing.IntervalDays = entity.IsRecurring ? entity.IntervalDays : null;
        existing.IntervalKm = entity.IsRecurring ? entity.IntervalKm : null;
        existing.IsPaymentRelated = entity.IsPaymentRelated;

        return await _unitOfWork.ReminderTypeRepository.UpdateAsync(existing);
    }

    public Task<bool> UpdateStatusAsync(int id, bool isActive)
        => _unitOfWork.ReminderTypeRepository.UpdateStatusAsync(id, isActive);
}
