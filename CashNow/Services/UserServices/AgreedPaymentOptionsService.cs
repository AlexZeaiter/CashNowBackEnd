using CashNow.DbContexts;
using CashNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class AgreedPaymentOptionsService
    {
        private readonly CompanyDbContext _context;

        public AgreedPaymentOptionsService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddAgreedPaymentOption(AgreedPaymentOptions agreedPaymentOptions)
        {
            agreedPaymentOptions.CreatedAt = DateTime.Now;
            _context.AgreedPaymentOptions.Add(agreedPaymentOptions);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgreedPaymentOption(AgreedPaymentOptions agreedPaymentOptions)
        {
            var CBI = _context.AgreedPaymentOptions.FindAsync(agreedPaymentOptions.AgreedPaymentOptionsId);

            CBI.Result.PayOnce = agreedPaymentOptions.PayOnce;
            CBI.Result.TwoMonthInstallments = agreedPaymentOptions.TwoMonthInstallments;
            CBI.Result.ThreeMonthsInstallments = agreedPaymentOptions.ThreeMonthsInstallments;
            CBI.Result.SixMonthsInstallments = agreedPaymentOptions.SixMonthsInstallments;
            CBI.Result.DateModified = agreedPaymentOptions.DateModified;

            await _context.SaveChangesAsync();
        }
    }
}
