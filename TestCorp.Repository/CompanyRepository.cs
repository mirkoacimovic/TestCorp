using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;

namespace TestCorp.Repository
{
    public class CompanyRepository
    {
        private readonly Test4CreateDbContext db;

        public CompanyRepository(Test4CreateDbContext context)
        {
            if (db == null)
                db = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await Task.FromResult(db.Companies);
        }

        public async Task<Company?> GetByAsync(Company item)
        {
            return await db.Companies.FindAsync(item);
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await db.Companies.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Company?> CreateAsync(Company item)
        {
            if (item != null)
            {
                await db.Companies.AddAsync(item);
                await db.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Company?> DeleteAsync(int id)
        {
            var company = await db.Companies.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (company != null)
            {
                db.Companies.Remove(company);
                await db.SaveChangesAsync();
                return company;
            }
            return null;
        }

        public async Task<Company?> UpdateAsync(Company item)
        {
            var company = await db.Companies.FindAsync(item);
            if (company != null)
            {
                db.Companies.Update(company);
                await db.SaveChangesAsync();
                return company;
            }
            return null;
        }

    }
}
