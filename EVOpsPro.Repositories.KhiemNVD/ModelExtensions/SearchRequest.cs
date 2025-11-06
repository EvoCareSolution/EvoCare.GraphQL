using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOpsPro.Repositories.KhiemNVD.ModelExtensions
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
    public class ReminderSearchRequest : SearchRequest
    {
        public int? ReminderTypeId { get; set; }
        public int? UserAccountId { get; set; }
        public DateTime? DueFrom { get; set; }
        public DateTime? DueTo { get; set; }
        public bool? IsSent { get; set; }
        public bool? IncludeInactive { get; set; }
        public bool? UpcomingOnly { get; set; }
        public bool? OnlyOverdue { get; set; }
    }
}
