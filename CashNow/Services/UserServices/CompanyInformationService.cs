using CashNow.DbContexts;
using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class CompanyInformationService
    {
        private readonly CompanyDbContext _context;

        public CompanyInformationService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyInformation(CompanyInformation companyInformation)
        {
            _context.CompanyInformation.Add(companyInformation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyInformation(CompanyInformation companyInformation)
        {
            var MUI = _context.CompanyInformation.FindAsync(companyInformation.CompanyId);

            MUI.Result.CompanyAddress = companyInformation.CompanyAddress;
            MUI.Result.CompanyCommercialRegister = companyInformation.CompanyCommercialRegister;
            MUI.Result.CompanyFlatFeesPerInvoice = companyInformation.CompanyFlatFeesPerInvoice;
            MUI.Result.CompanyName = companyInformation.CompanyName;
            MUI.Result.CompanyRatePerFiftnCalendarDays = companyInformation.CompanyRatePerFiftnCalendarDays;
            MUI.Result.CompanyRepContactName = companyInformation.CompanyRepContactName;
            MUI.Result.CompanyRepEmailAddress = companyInformation.CompanyRepEmailAddress;
            MUI.Result.CompanyRepMobileNumber = companyInformation.CompanyRepMobileNumber;
            MUI.Result.CompanySize = companyInformation.CompanySize;
            MUI.Result.CompanyTaxId = companyInformation.CompanyTaxId;
            MUI.Result.CompanyType = companyInformation.CompanyType;
            MUI.Result.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<CompanyInformation> GetCompanyInformation(Guid compnayId)
        {
            return await _context.CompanyInformation.Where(x => x.CompanyId == compnayId).FirstOrDefaultAsync();
        }


    }
}
