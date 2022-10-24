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
    [Route("api/admininfo")]
    [ApiController]
    public class AdminInfoController : Controller
    {
        private AdminInfoService _adminInfoService;

        public AdminInfoController(AdminDbContext context)
        {
            _adminInfoService = new AdminInfoService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAdminInfo(AdminInfo adminInfo)
        {
            adminInfo.CreatedAt = DateTime.Now;
            await _adminInfoService.AddAdminInfo(adminInfo);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateAdminInfo(AdminInfo adminInfo)
        {
            await _adminInfoService.UpdateAdminInfo(adminInfo);
            return true;
        }
    }
}
