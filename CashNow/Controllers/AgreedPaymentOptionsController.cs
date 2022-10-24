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
    [Route("api/agreedpaymentoptions")]
    [ApiController]
    public class AgreedPaymentOptionsController : Controller
    {
        private AgreedPaymentOptionsService _agreedPaymentOptionsService;

        public AgreedPaymentOptionsController(CompanyDbContext context)
        {
            _agreedPaymentOptionsService = new AgreedPaymentOptionsService(context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddAgreedPaymentOption(AgreedPaymentOptions agreedPaymentOptions)
        {
            agreedPaymentOptions.CreatedAt = DateTime.Now;
            await _agreedPaymentOptionsService.AddAgreedPaymentOption(agreedPaymentOptions);

            return true;
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateAgreedPaymentOption(AgreedPaymentOptions agreedPaymentOptions)
        {
            await _agreedPaymentOptionsService.UpdateAgreedPaymentOption(agreedPaymentOptions);
            return true;
        }
    }
}
