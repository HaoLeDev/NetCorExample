using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Data
{
    public class DemoContext: DbContext
    {
        public DemoContext() : base() { }
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SERVER=HAOLV;DATABASE=DemoLogin;UID=sa;PWD=123456;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
