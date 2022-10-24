using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class CompanyLogin
    {
        public Guid CompanyLoginId { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyUserPassword { get; set; }
        public string CompanyEmailAddress { get; set; }
        public int RegistrationRequestId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
