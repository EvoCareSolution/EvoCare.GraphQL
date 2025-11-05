using EVOpsPro.Repositories.KhiemNVD.Basic;
using EVOpsPro.Repositories.KhiemNVD.DBContext;
using EVOpsPro.Repositories.KhiemNVD.Models;
using Microsoft.EntityFrameworkCore;

namespace EVOpsPro.Repositories.KhiemNVD;

public class ReminderTypeKhiemNvdRepository : GenericRepository<ReminderTypeKhiemNvd>
{
    public ReminderTypeKhiemNvdRepository()
    {
    }

    public ReminderTypeKhiemNvdRepository(FA25_PRN232_SE1713_G2_EVOpsProContext context) => _context = context;

    public Task<List<ReminderTypeKhiemNvd>> GetAllAsync(bool includeInactive = false)
    {
        var query = _context.ReminderTypeKhiemNvds.AsQueryable();
        if (!includeInactive)
        {
            query = query.Where(t => t.IsActive);
        }

        return query
            .OrderByDescending(t => t.IsActive)
            .ThenBy(t => t.TypeName)
            .ToListAsync();
    }

    public Task<ReminderTypeKhiemNvd?> GetByIdAsync(int id)
        => _context.ReminderTypeKhiemNvds.FirstOrDefaultAsync(t => t.ReminderTypeKhiemNvdid == id);

    public async Task<bool> UpdateStatusAsync(int id, bool isActive)
    {
        var type = await _context.ReminderTypeKhiemNvds.FirstOrDefaultAsync(t => t.ReminderTypeKhiemNvdid == id);
        if (type == null)
        {
            return false;
        }

        type.IsActive = isActive;
        await _context.SaveChangesAsync();
        return true;
    }
}
