using CashNow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.DbContexts
{
    public class AdminDbContext : DbContext
    {
        public DbSet<AdminInfo> AdminInfo { get; set; }
        public DbSet<AdminRoles> AdminRoles { get; set; }


        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }
    }
}
