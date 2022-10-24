using CashNow.DbContexts;
using CashNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class AdminInfoService
    {
        private readonly AdminDbContext _context;

        public AdminInfoService(AdminDbContext context)
        {
            _context = context;
        }

        public async Task AddAdminInfo(AdminInfo adminInfo)
        {
            adminInfo.CreatedAt = DateTime.Now;
            _context.AdminInfo.Add(adminInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminInfo(AdminInfo adminInfo)
        {
            var AI = _context.AdminInfo.FindAsync(adminInfo.AdminUserId);

            AI.Result.AdminUserName = adminInfo.AdminUserName;
            AI.Result.AdminUserPassword = adminInfo.AdminUserPassword;
            AI.Result.AdminUserFullName = adminInfo.AdminUserFullName;
            AI.Result.AdminUserEmailAddress = adminInfo.AdminUserEmailAddress;
            AI.Result.AdminRoleId = adminInfo.AdminRoleId;
            AI.Result.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
