﻿using TestCorp.Domain.Models.Enums;

namespace TestCorp.WebAPI.Models
{
    public class EmployeeDTO
    {
        public string? Email { get; set; }
        public EmployeeType Title { get; set; }
        public IEnumerable<int>? CompanyIds { get; set; }
    }
}
