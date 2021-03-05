using EralpSoftwareApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using EralpSoftwareApplication.Models.DTOs;

namespace EralpSoftwareApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeesController : Controller
    {
        private readonly AppsContext _context;

        public EmployeesController(AppsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployeesByDate()
        {
            var employee_List = _context.Employees.ToList().OrderByDescending(x => x.DateCreated);
            return Json(new { data = employee_List, success = true, message = "Process is success" });
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var chosen_Employee = _context.Employees.Where(p => p.EmployeeId == id);
            if (chosen_Employee is null) 
                return NotFound();
            return Json(new { data = chosen_Employee, success = true, message = "Process is success" });
        }

        [HttpGet]
        public IActionResult GetEmployeesByDepartment() 
        {
            DepartmentDTO[] dept = _context.Departments.ToArray();
            EmployeeDTO[] emp = _context.Employees.ToArray();
            var employee_departmentList = from d in dept
                      join e in emp on d.DepartmentId equals e.DepartmentId into cs
                      from e in cs.DefaultIfEmpty()
                      group e by d into g
                      select new
                      {
                          Departments = g.Key,
                          Employees = g.Where(x => x != null).ToList()
                      };
            return Json(new { data = employee_departmentList, success = true, message = "Process is success" });
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDTO employeeDto)
        {
            var employee = new EmployeeDTO {
                EmployeeName = employeeDto.EmployeeName,
                EmployeeSurname = employeeDto.EmployeeSurname,
                DepartmentId = employeeDto.DepartmentId,
                CompanyId = employeeDto.CompanyId,
                DateCreated = System.DateTime.Now,
                DateModified = System.DateTime.Now
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.EmployeeId == id);
            if (employee is null)
            {
                employee = new EmployeeDTO
                {
                    EmployeeName = employeeDto.EmployeeName,
                    EmployeeSurname = employeeDto.EmployeeSurname,
                    DepartmentId = employeeDto.DepartmentId,
                    CompanyId = employeeDto.CompanyId,
                    DateCreated = System.DateTime.Now,
                    DateModified = System.DateTime.Now
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            employee.CompanyId = employeeDto.CompanyId;
            employee.DateModified = System.DateTime.Now;
            _context.SaveChanges();
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.EmployeeId == id);
            if (employee is null) 
                return NotFound();
            _context.Remove(employee);
            _context.SaveChanges();
            return Json(new { data = _context.Employees.ToList(), success = true, message = "Process is success" });
        }
    }
}