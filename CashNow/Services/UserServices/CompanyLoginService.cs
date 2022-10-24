using CashNow.DbContexts;
using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.LoginServices
{
    public class CompanyLoginService
    {
        private readonly CompanyDbContext _context;

        public CompanyLoginService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyLogin(CompanyLogin companyLogin)
        {
            _context.CompanyLogin.Add(companyLogin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyLoginPassword(CompanyLogin companyLogin)
        {
            var MUL = _context.CompanyLogin.FindAsync(companyLogin.CompanyLoginId);
            MUL.Result.CompanyUserPassword = companyLogin.CompanyUserPassword;
            MUL.Result.DateModified = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public CompanyLogin AuthenticateCompanyLogin(string companyEmailAddressOrUserName, string companyPassword)
        {
            if (string.IsNullOrEmpty(companyEmailAddressOrUserName) || string.IsNullOrEmpty(companyPassword))
                return null;

            var user = _context.CompanyLogin.SingleOrDefault(x => x.CompanyEmailAddress == companyEmailAddressOrUserName || x.CompanyUserName == companyEmailAddressOrUserName);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (user.CompanyUserPassword != companyPassword)
                return null;

            // authentication successful
            return user;
        }

        public async Task<CompanyLogin> GetUser(string email)
        {
            return await _context.CompanyLogin.SingleOrDefaultAsync(x => x.CompanyEmailAddress == email);
        }
    }
}
