using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestCorp.Domain.Models.Enums;

namespace TestCorp.Domain.Models
{
    [Table("employee")]
    public class Employee : BaseEntity
    {
        [Key, Required]
        public new int Id { get; set; }
        public EmployeeType Title { get; set; }
        public string? Email { get; set; }

        public ICollection<CompanyEmployee>? CompanyEmployees { get; set; }
    }
}
