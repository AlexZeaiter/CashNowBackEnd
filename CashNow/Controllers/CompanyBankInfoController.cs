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
    [Route("api/companybankinfo")]
    [ApiController]

    public class CompanyBankInfoController : Controller
    {
        private CompanyBankInfoService _companyBankInfoService;

        public CompanyBankInfoController(CompanyDbContext context)
        {
            _companyBankInfoService = new CompanyBankInfoService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddMasterUserLogin(CompanyBankInfo companyBankInfo)
        {
            companyBankInfo.CreatedAt = DateTime.Now;
            await _companyBankInfoService.AddCompanyBankInfo(companyBankInfo);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateMasterUserLogin(CompanyBankInfo companyBankInfo)
        {
            await _companyBankInfoService.UpdateCompanyBankInfo(companyBankInfo);
            return true;
        }
    }
}
