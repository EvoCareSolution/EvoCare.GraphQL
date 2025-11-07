using EVOpsPro.Repositories.KhiemNVD.ModelExtensions;
using EVOpsPro.Repositories.KhiemNVD.Models;
using EVOpsPro.Servcies.KhiemNVD;

namespace EVOpsPro.GraphQLWebAPI.KhiemNVD.GraphQLs
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProviders;
        public Queries(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders ?? throw new ArgumentNullException(nameof(serviceProviders));
        public Task<List<ReminderKhiemNvd>> GetReminderKhiemNvds(ReminderSearchRequest? request)
        {
            return _serviceProviders.ReminderKhiemNvdService.GetAllAsync(request);
        }

        public Task<PaginationResult<List<ReminderKhiemNvd>>> GetReminderKhiemNvdsWithPaging(ReminderSearchRequest request)
        {
            return _serviceProviders.ReminderKhiemNvdService.SearchWithPagingAsync(request);
        }

        public Task<ReminderKhiemNvd?> GetReminderKhiemNvd(int id)
        {
            return _serviceProviders.ReminderKhiemNvdService.GetByIdAsync(id);
        }

        public Task<List<ReminderTypeKhiemNvd>> GetReminderTypes(bool includeInactive = false)
        {
            return _serviceProviders.ReminderTypeKhiemNvdService.GetAllAsync(includeInactive);
        }

        public Task<ReminderTypeKhiemNvd?> GetReminderType(int id)
        {
            return _serviceProviders.ReminderTypeKhiemNvdService.GetByIdAsync(id);
        }

        public Task<List<SystemUserAccount>> GetSystemUserAccounts()
        {
            return _serviceProviders.UserAccountService.GetActiveUsersAsync();
        }

    }
}
