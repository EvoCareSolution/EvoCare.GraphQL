using EVOpsPro.GraphQLWebAPI.KhiemNVD.GraphQLs.Inputs;
using EVOpsPro.Repositories.KhiemNVD.ModelExtensions;
using EVOpsPro.Repositories.KhiemNVD.Models;
using EVOpsPro.Servcies.KhiemNVD;
using HotChocolate;

namespace EVOpsPro.GraphQLWebAPI.KhiemNVD.GraphQLs
{
    public class Mutations
    {
        private readonly IServiceProviders _serviceProviders;
        public Mutations(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders ?? throw new ArgumentNullException(nameof(serviceProviders));

        public async Task<SystemUserAccount> Login(string username, string password)
        {
            var user = await _serviceProviders.UserAccountService.GetUserAccount(username, password);
            if (user == null)
                throw new GraphQLException(new Error("Invalid username or password", "AUTH_FAILED"));

            return user;
        }

        public Task<int> CreateReminder(ReminderKhiemNvdInput reminder)
        {
            return _serviceProviders.ReminderKhiemNvdService.CreateAsync(reminder.ToEntity());
        }

        public Task<int> UpdateReminder(ReminderKhiemNvdInput reminder)
        {
            if (!(reminder.ReminderKhiemNvdid > 0))
            {
                throw new GraphQLException(new Error("Reminder id is required", "REMINDER_ID_REQUIRED"));
            }
            return _serviceProviders.ReminderKhiemNvdService.UpdateAsync(reminder.ToEntity());
        }

        public Task<bool> DeleteReminder(int id)
        {
            return _serviceProviders.ReminderKhiemNvdService.DeleteAsync(id);
        }

        public Task<bool> MarkReminderAsSent(int id, DateTime? sentAtUtc = null)
        {
            return _serviceProviders.ReminderKhiemNvdService.MarkAsSentAsync(id, sentAtUtc);
        }

        public Task<int> CreateReminderType(ReminderTypeKhiemNvdInput reminderType)
        {
            return _serviceProviders.ReminderTypeKhiemNvdService.CreateAsync(reminderType.ToEntity());
        }

        public Task<int> UpdateReminderType(ReminderTypeKhiemNvdInput reminderType)
        {
            if (!(reminderType.ReminderTypeKhiemNvdid > 0))
            {
                throw new GraphQLException(new Error("Reminder type id is required", "REMINDER_TYPE_ID_REQUIRED"));
            }
            return _serviceProviders.ReminderTypeKhiemNvdService.UpdateAsync(reminderType.ToEntity());
        }

        public Task<bool> UpdateReminderTypeStatus(int id, bool isActive)
        {
            return _serviceProviders.ReminderTypeKhiemNvdService.UpdateStatusAsync(id, isActive);
        }
    }
}
