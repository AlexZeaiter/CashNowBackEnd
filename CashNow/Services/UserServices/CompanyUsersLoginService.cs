using CashNow.DbContexts;
using CashNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class CompanyUsersLoginService
    {
        private readonly CompanyDbContext _context;

        public CompanyUsersLoginService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyUsersLogin(CompanyUsersLogin companyUserLogin)
        {
            companyUserLogin.CreatedAt = DateTime.Now;
            _context.CompanyUserLogin.Add(companyUserLogin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyUsersLogin(CompanyUsersLogin companyUserLogin)
        {
            var SUL = _context.CompanyUserLogin.FindAsync(companyUserLogin.CompanyUserLoginId);

            SUL.Result.CompanyUserFullName = companyUserLogin.CompanyUserFullName;
            SUL.Result.CompanyUserPassword = companyUserLogin.CompanyUserPassword;
            SUL.Result.CompanyUserPhoneNumber = companyUserLogin.CompanyUserPhoneNumber;
            SUL.Result.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public CompanyUsersLogin AuthenticateCompanyUsersLogin(string companyUserEmailAddress, string companyUserPassword)
        {
            if (string.IsNullOrEmpty(companyUserEmailAddress) || string.IsNullOrEmpty(companyUserPassword))
                return null;

            var user = _context.CompanyUserLogin.SingleOrDefault(x => x.CompanyUserEmailAddress == companyUserEmailAddress);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (user.CompanyUserPassword != companyUserPassword)
                return null;

            // authentication successful
            return user;
        }
    }
}
