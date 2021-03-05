using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EralpSoftwareApplication.Models.DTOs
{
    public class CompanyDTO
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
