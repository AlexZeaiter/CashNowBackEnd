using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class RegistrationRequest
    {
        public int RegistrationRequestId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public DateTime YearOfEstablishment { get; set; }
        public int CompanySize { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyRepContactName { get; set; }
        public int CompanyRepPhoneNumber { get; set; }
        public string CompanyRepEmailAddress { get; set; }
        public string InterestedIn { get; set; }
        public bool IsApproved { get; set; }
    }
}
