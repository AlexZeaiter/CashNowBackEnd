using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class CompanyInformation
    {
        public int CompanyInformationId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? YearOfEstablishment { get; set; }
        public int? CompanySize { get; set; }
        public string CompanyType { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCommercialRegister { get; set; }
        public string CompanyTaxId { get; set; }
        public int? CompanyRatePerFiftnCalendarDays { get; set; }
        public int? CompanyFlatFeesPerInvoice { get; set; }
        public int? GracePeriodInDays { get; set; }
        public double? InstallmentRate { get; set; }
        public string CompanyRepContactName { get; set; }
        public string CompanyRepMobileNumber { get; set; }
        public string CompanyRepEmailAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
