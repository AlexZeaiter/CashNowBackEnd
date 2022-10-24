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
    [Route("api/subuser")]
    [ApiController]

    public class CompanyUsersLoginController : Controller
    {
        private CompanyUsersLoginService _subUserLoginService;

        public CompanyUsersLoginController(CompanyDbContext context)
        {
            _subUserLoginService = new CompanyUsersLoginService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddSubUserLogin(CompanyUsersLogin subUserLogin)
        {
            subUserLogin.CreatedAt = DateTime.Now;
            await _subUserLoginService.AddCompanyUsersLogin(subUserLogin);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateSubUserLogin(CompanyUsersLogin subUserLogin)
        {
            await _subUserLoginService.UpdateCompanyUsersLogin(subUserLogin);
            return true;
        }

        [HttpPost("login")]
        public IActionResult SubUserAuthenticate(AuthenticateModel model)
        {
            var user = _subUserLoginService.AuthenticateCompanyUsersLogin(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new
            {
                Username = user.CompanyUserEmailAddress
            });
        }

    }
}
