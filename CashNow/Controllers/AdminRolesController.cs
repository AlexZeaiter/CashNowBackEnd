using CashNow.DbContexts;
using CashNow.Models;
using CashNow.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Controllers
{
    [Route("api/adminrole")]
    [ApiController]
    public class AdminRolesController : Controller
    {
        private AdminRolesService _adminRolesService;

        public AdminRolesController(AdminDbContext context)
        {
            _adminRolesService = new AdminRolesService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAdminRole(AdminRoles adminRoles)
        {
            adminRoles.CreatedAt = DateTime.Now;
            await _adminRolesService.AddAdminRole(adminRoles);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateAdminRole(AdminRoles adminRoles)
        {
            await _adminRolesService.UpdateAdminRole(adminRoles);
            return true;
        }
    }
}
