using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AgreedPaymentOptions
    {
        public int AgreedPaymentOptionsId { get; set; }
        public Guid CompanyId { get; set; }
        public bool? PayOnce { get; set; }
        public bool? TwoMonthInstallments { get; set; }
        public bool? ThreeMonthsInstallments { get; set; }
        public bool? SixMonthsInstallments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
