using EralpSoftwareApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EralpSoftwareApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class DepartmentsController : Controller
    {
        private readonly AppsContext _context;

        public DepartmentsController(AppsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments_List = _context.Departments.ToList();
            return Json(new { data = departments_List, success = true, message = "Process is success" });
        }


        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var chosen_Department = _context.Departments.Where(p => p.DepartmentId == id); ;
            if (chosen_Department is null)
                return NotFound();
            return Json(new { data = chosen_Department, success = true, message = "Process is success" });
        }
    }
}
