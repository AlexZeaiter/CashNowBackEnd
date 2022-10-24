using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CashNow.DbContexts;
using CashNow.Models;
using CashNow.Services.UserServices;

namespace CashNow.Controllers
{
    [Route("api/masteruserinformation")]
    [ApiController]
    public class CompanyInformationContoller : Controller
    {
        private CompanyInformationService _masterUserInformationService;

        public CompanyInformationContoller(CompanyDbContext context)
        {
            _masterUserInformationService = new CompanyInformationService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddMasterUserLogin(CompanyInformation masterUserInformation)
        {
            masterUserInformation.CompanyId = new Guid();
            masterUserInformation.CreatedAt = DateTime.Now;
            await _masterUserInformationService.AddCompanyInformation(masterUserInformation);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateMasterUserLogin(CompanyInformation masterUserInformation)
        {
            await _masterUserInformationService.UpdateCompanyInformation(masterUserInformation);
            return true;
        }
    }
}
