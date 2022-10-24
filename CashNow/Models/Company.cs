using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public Guid CompanyLoginId { get; set; }
        public int CompanyInformationId { get; set; }
        public int CompanyBankInfoId { get; set; }
        public int AgreedPaymentOptionsId { get; set; }
    }
}
