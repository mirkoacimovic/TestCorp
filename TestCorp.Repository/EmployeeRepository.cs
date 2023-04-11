using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;

namespace TestCorp.Repository
{
    public class EmployeeRepository
    {
        private readonly Test4CreateDbContext db;

        public EmployeeRepository(Test4CreateDbContext context) 
        {
            if (db == null)
                db = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await Task.FromResult(db.Employees);
        }

        public async Task<Employee?> GetByAsync(Employee item)
        {
            return await db.Employees.FindAsync(item);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await db.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Employee?> CreateAsync(Employee item)
        {
            if(item != null)
            {
                await db.Employees.AddAsync(item);
                await db.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employee = await db.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee?> UpdateAsync(Employee item)
        {
            var employee = await db.Employees.FindAsync(item);
            if (employee != null)
            {
                db.Employees.Update(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            return null;
        }
    }
}
