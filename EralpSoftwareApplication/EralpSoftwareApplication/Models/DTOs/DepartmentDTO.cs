﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EralpSoftwareApplication.Models.DTOs
{
    public class DepartmentDTO
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
