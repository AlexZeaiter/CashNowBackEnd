using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class CompanyUsersLogin
    {
        [Key]
        public int CompanyUserLoginId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyUserEmailAddress { get; set; }
        public string CompanyUserPassword { get; set; }
        public string CompanyUserFullName { get; set; }
        public string CompanyUserPhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }

    }
}
