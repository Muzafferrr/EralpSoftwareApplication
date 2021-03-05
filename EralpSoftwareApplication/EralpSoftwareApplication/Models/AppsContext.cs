using EralpSoftwareApplication.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EralpSoftwareApplication.Models
{
    public class AppsContext :DbContext
    {

        public AppsContext(DbContextOptions<AppsContext> options) : base(options) { }
        public DbSet<CompanyDTO> Companies { get; set; }
        public DbSet<DepartmentDTO> Departments { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }
    }
}
