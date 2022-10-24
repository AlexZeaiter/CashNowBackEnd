using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.DbContexts
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<AgreedPaymentOptions> AgreedPaymentOptions { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyBankInfo> CompanyBankInfo { get; set; }
        public DbSet<CompanyBillingCycle> CompanyBillingCycle { get; set; }
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<CompanyLogin> CompanyLogin { get; set; }
        public DbSet<CompanyUsersLogin> CompanyUserLogin { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }
    }
}
