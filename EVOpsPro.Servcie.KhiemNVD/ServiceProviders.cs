using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOpsPro.Servcies.KhiemNVD
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        ReminderKhiemNvdService ReminderKhiemNvdService { get; }
        ReminderTypeKhiemNvdService ReminderTypeKhiemNvdService { get; }
    }
    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _userAccountService;
        private ReminderKhiemNvdService _reminderService;
        private ReminderTypeKhiemNvdService _reminderTypeService;

        public ServiceProviders() { }

        public SystemUserAccountService UserAccountService
        {
            get { return _userAccountService ??= new SystemUserAccountService(); }

        }
        public ReminderKhiemNvdService ReminderKhiemNvdService
        {
            get { return _reminderService ??= new ReminderKhiemNvdService(); }
        }

        public ReminderTypeKhiemNvdService ReminderTypeKhiemNvdService
        {
            get { return _reminderTypeService ??= new ReminderTypeKhiemNvdService(); }
        }
    }
}
