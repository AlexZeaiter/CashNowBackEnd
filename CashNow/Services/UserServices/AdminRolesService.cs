using CashNow.DbContexts;
using CashNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class AdminRolesService
    {
        private readonly AdminDbContext _context;

        public AdminRolesService(AdminDbContext context)
        {
            _context = context;
        }

        public async Task AddAdminRole(AdminRoles adminRoles)
        {
            adminRoles.CreatedAt = DateTime.Now;
            _context.AdminRoles.Add(adminRoles);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminRole(AdminRoles adminRoles)
        {
            var CBI = _context.AdminRoles.FindAsync(adminRoles.AdminRoleId);
            CBI.Result.RoleName = adminRoles.RoleName;

            await _context.SaveChangesAsync();
        }
    }
}
