using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class CompanyBillingCycle
    {
        public int CompanyBillingCycleId { get; set; }
        public Guid CompanyId { get; set; }
        public int? BillingDayOfMonth { get; set; }
        public int? BillingDayOfWeek { get; set; }
        public int? MinimumBillingCycleDays { get; set; }
    }
}
