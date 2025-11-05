using EVOpsPro.Repositories.KhiemNVD.Basic;
using EVOpsPro.Repositories.KhiemNVD.DBContext;
using EVOpsPro.Repositories.KhiemNVD.ModelExtensions;
using EVOpsPro.Repositories.KhiemNVD.Models;
using Microsoft.EntityFrameworkCore;

namespace EVOpsPro.Repositories.KhiemNVD;

public class ReminderKhiemNvdRepository : GenericRepository<ReminderKhiemNvd>
{
    public ReminderKhiemNvdRepository()
    {
    }

    public ReminderKhiemNvdRepository(FA25_PRN232_SE1713_G2_EVOpsProContext context) => _context = context;

    private IQueryable<ReminderKhiemNvd> BuildQueryable(ReminderSearchRequest? request)
    {
        var query = _context.ReminderKhiemNvds
            .Include(r => r.SystemUserAccount)
            .Include(r => r.ReminderTypeKhiemNvd)
            .AsQueryable();

        if (request == null || request.IncludeInactive != true)
        {
            query = query.Where(r => r.IsActive);
        }

        if (request != null)
        {
            if (request.UserAccountId.HasValue)
                query = query.Where(r => r.UserAccountId == request.UserAccountId.Value);

            if (request.ReminderTypeId.HasValue)
                query = query.Where(r => r.ReminderTypeKhiemNvdid == request.ReminderTypeId.Value);

            if (request.DueFrom.HasValue)
                query = query.Where(r => r.DueDate >= request.DueFrom.Value);

            if (request.DueTo.HasValue)
                query = query.Where(r => r.DueDate <= request.DueTo.Value);

            if (request.IsSent.HasValue)
                query = query.Where(r => r.IsSent == request.IsSent.Value);

            if (request.UpcomingOnly == true)
            {
                var today = DateTime.UtcNow.Date;
                query = query.Where(r => r.DueDate >= today);
            }

            if (request.OnlyOverdue == true)
            {
                var today = DateTime.UtcNow.Date;
                query = query.Where(r => r.DueDate < today && !r.IsSent);
            }
        }

        return query.OrderBy(r => r.DueDate).ThenBy(r => r.VehicleVin);
    }

    public Task<List<ReminderKhiemNvd>> GetAllAsync(ReminderSearchRequest? request = null)
        => BuildQueryable(request).ToListAsync();

    public Task<ReminderKhiemNvd?> GetByIdAsync(int id)
        => BuildQueryable(new ReminderSearchRequest { IncludeInactive = true })
            .FirstOrDefaultAsync(r => r.ReminderKhiemNvdid == id);

    public async Task<PaginationResult<List<ReminderKhiemNvd>>> SearchWithPagingAsync(ReminderSearchRequest request)
    {
        request ??= new ReminderSearchRequest();
        request.CurrentPage ??= 1;
        request.PageSize ??= 10;

        var query = BuildQueryable(request);

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize.Value);

        var items = await query
            .Skip((request.CurrentPage.Value - 1) * request.PageSize.Value)
            .Take(request.PageSize.Value)
            .ToListAsync();

        return new PaginationResult<List<ReminderKhiemNvd>>
        {
            CurrentPage = request.CurrentPage.Value,
            PageSize = request.PageSize.Value,
            TotalItems = totalItems,
            TotalPages = totalPages,
            Items = items
        };
    }

    public async Task<bool> MarkAsSentAsync(int reminderId, DateTime? sentAtUtc = null)
    {
        var reminder = await _context.ReminderKhiemNvds.FirstOrDefaultAsync(r => r.ReminderKhiemNvdid == reminderId);
        if (reminder == null)
        {
            return false;
        }

        reminder.IsSent = true;
        reminder.ModifiedDate = sentAtUtc ?? DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}
