using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashNow.DbContexts;
using CashNow.Models;
using CashNow.Services.LoginServices;
using Microsoft.AspNetCore.Authorization;
using CashNow.Services.UserServices;
using CashNow.Models.RequestModels;

namespace CashNow.Controllers
{
    [Route("api/companylogin")]
    [ApiController]
    public class CompanyLoginController : ControllerBase
    {
        private CompanyLoginService _companyLoginService ;
        private CompanyInformationService _companyInformationService;
        private RegistrationRequestService _registrationRequestService;
        public CompanyLoginController(CompanyDbContext companyDbContext, 
            CompanyInformationService companyInformationService)
        {
            _companyLoginService = new CompanyLoginService(companyDbContext);
            _companyInformationService = companyInformationService;
            _registrationRequestService = new RegistrationRequestService(companyDbContext);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestModel rq)
        {
            RegistrationRequest r_Request = new RegistrationRequest();
            r_Request.CompanyName = rq.CompanyName;
            r_Request.CompanyAddress = rq.CompanyAddress;
            r_Request.CompanyRepContactName = rq.CompanyRepContactName;
            r_Request.CompanyRepEmailAddress = rq.CompanyRepEmailAddress;
            r_Request.CompanyRepPhoneNumber = rq.CompanyRepPhoneNumber;
            r_Request.CompanySize = rq.CompanySize;
            r_Request.CompanyType = rq.CompanyType;
            r_Request.InterestedIn = rq.InterestedIn;
            r_Request.IsApproved = false;
            r_Request.YearOfEstablishment = rq.YearOfEstablishment;

            await _registrationRequestService.AddRegistrationRequest(r_Request);

            r_Request = await _registrationRequestService.GetRegistrationRequestByEmail(rq.CompanyRepEmailAddress);

            CompanyLogin companyLogin = new CompanyLogin();

            companyLogin.CompanyEmailAddress = rq.CompanyEmailAddress;
            companyLogin.CompanyUserName = rq.CompanyUserName;
            companyLogin.CompanyUserPassword = rq.CompanyPassword;
            companyLogin.RegistrationRequestId = r_Request.RegistrationRequestId;
            companyLogin.CreatedAt = DateTime.Now;


            await _companyLoginService.AddCompanyLogin(companyLogin);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            var user = _companyLoginService.AuthenticateCompanyLogin(model.UserName, model.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            CompanyInformation CI = new CompanyInformation();
            if (user.CompanyId.HasValue)
            {
                 CI = await _companyInformationService.GetCompanyInformation(user.CompanyId.Value);
                if(CI != null)
                {
                    return Ok(new
                    {
                        Username = CI.CompanyName,
                        CompanyId = user.CompanyId
                    });
                }
                return Ok(new
                {
                    Username = "New Company",
                    CompanyId = user.CompanyId
                });
            }

            return Ok(new
            {
                Username = CI.CompanyName,
                CompanyId = user.CompanyLoginId
            });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddCompanyLogin(CompanyLogin masterUserLogin)
        {
            masterUserLogin.CompanyLoginId = new Guid();
            masterUserLogin.CreatedAt = DateTime.Now;
            await _companyLoginService.AddCompanyLogin(masterUserLogin);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateCompanyLogin(CompanyLogin masterUserLogin)
        {
            await _companyLoginService.UpdateCompanyLoginPassword(masterUserLogin);
            return true;
        }
    }
}
