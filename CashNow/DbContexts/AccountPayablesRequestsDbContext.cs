using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.DbContexts
{
    public class AccountPayablesRequestsDbContext : DbContext
    {
        public DbSet<AccountPayablesRequests> AccountPayablesRequests { get; set; }
        public DbSet<AP_OrderDetailsHeader> AP_OrderDetailsHeader { get; set; }
        public DbSet<AP_OrderDetailsItems> AP_OrderDetailsItems { get; set; }
        public DbSet<APRequestDetails> APRequestDetails { get; set; }
        public DbSet<BeneficiaryDetails> BeneficiaryDetails { get; set; }
        public DbSet<BeneficiaryInvoiceDetails> BeneficiaryInvoiceDetails { get; set; }
        public DbSet<SupportingDocuments> SupportingDocuments { get; set; }

        public AccountPayablesRequestsDbContext(DbContextOptions<AccountPayablesRequestsDbContext> options) : base(options)
        {
        }
    }
}
