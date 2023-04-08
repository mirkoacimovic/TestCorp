using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCorp.Domain.Models
{
    [Table("company_employee")]
    public class CompanyEmployee
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
