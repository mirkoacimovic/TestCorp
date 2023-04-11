using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;
using TestCorp.Services.Interfaces;

namespace TestCorp.Services
{
    public class ValidationService : IValidationService
    {
        private readonly Test4CreateDbContext db;

        public ValidationService(Test4CreateDbContext context)
        {
            db = context;
        }

        public async Task<bool> ValidateEmployee(Employee employee, int companyId)
        {
            return false;
        }
    }
}
