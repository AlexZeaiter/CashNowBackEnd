using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class CompanyBankInfo
    {
        public int CompanyBankInfoId { get; set; }
        public Guid CompanyId { get; set; }
        public string BankName { get; set; }
        public string BankCountry { get; set; }
        public string iBanAccountNumber { get; set; }
        public string AccountCurrency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
