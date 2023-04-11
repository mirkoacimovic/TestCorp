using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Models;

namespace TestCorp.Domain.Data
{
    public class Test4CreateDbContext : DbContext
    {
        public Test4CreateDbContext(DbContextOptions<Test4CreateDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
        public DbSet<SystemLog> SystemLog { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.UseSerialColumns();
           builder.Entity<CompanyEmployee>().HasKey(ce => new { ce.EmployeeId, ce.CompanyId });
           builder.Entity<Employee>()
                   .Property(p => p.Id)
           .ValueGeneratedOnAdd();
            builder.Entity<Company>()
                    .Property(p => p.Id)
            .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);
        }

    }
}
