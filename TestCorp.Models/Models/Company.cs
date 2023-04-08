using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCorp.Domain.Models
{
    [Table("company")]
    public class Company : BaseEntity
    {
        [Key, Required]
        public new int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<CompanyEmployee>? CompanyEmployees { get; set; }
    }
}
