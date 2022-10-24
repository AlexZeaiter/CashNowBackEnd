using CashNow.DbContexts;
using CashNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class CompanyBankInfoService
    {
        private readonly CompanyDbContext _context;

        public CompanyBankInfoService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyBankInfo(CompanyBankInfo companyBankInfo)
        {
            companyBankInfo.CreatedAt = DateTime.Now;
            _context.CompanyBankInfo.Add(companyBankInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyBankInfo(CompanyBankInfo companyBankInfo)
        {
            var CBI = _context.CompanyBankInfo.FindAsync(companyBankInfo.CompanyBankInfoId);

            CBI.Result.AccountCurrency = companyBankInfo.AccountCurrency;
            CBI.Result.BankCountry = companyBankInfo.BankCountry;
            CBI.Result.BankName = companyBankInfo.BankName;
            CBI.Result.iBanAccountNumber = companyBankInfo.iBanAccountNumber;
            CBI.Result.DateModified = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
