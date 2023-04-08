using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Models.Enums;

namespace TestCorp.Domain.Models
{
    [Table("systemlog")]
    public class SystemLog : BaseEntity
    {
        [Key, Required]
        public new int Id { get; set; }
        public ResourceType ResourceType { get; set; }
        public string? Changeset { get; set; }
        public EventType Event { get; set; }
        public string? Comment { get; set; }
    }
}
