using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Core.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
