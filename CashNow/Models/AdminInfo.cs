using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AdminInfo
    {
        public Guid AdminUserId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminUserPassword { get; set; }
        public string AdminUserFullName { get; set; }
        public string AdminUserEmailAddress { get; set; }
        public int AdminRoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
