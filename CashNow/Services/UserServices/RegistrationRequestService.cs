using CashNow.DbContexts;
using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Services.UserServices
{
    public class RegistrationRequestService
    {
        private readonly CompanyDbContext _context;

        public RegistrationRequestService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddRegistrationRequest(RegistrationRequest registrationRequest)
        {
            _context.RegistrationRequests.Add(registrationRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<RegistrationRequest> GetRegistrationRequestByEmail(string companyRepEmail)
        {
            return await _context.RegistrationRequests.SingleOrDefaultAsync(x => x.CompanyRepEmailAddress == companyRepEmail);
        }
    }
}
