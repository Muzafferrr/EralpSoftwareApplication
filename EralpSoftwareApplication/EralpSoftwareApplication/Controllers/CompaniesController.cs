using EralpSoftwareApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EralpSoftwareApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class CompaniesController : Controller
    {
        private readonly AppsContext _context;

        public CompaniesController(AppsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var company_List = _context.Companies.ToList();
            return Json(new { data = company_List, success = true, message = "Process is success" });
        }
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var chosen_Company = _context.Companies.Where(p => p.CompanyId == id); ;
            if (chosen_Company is null)
                return NotFound();
            return Json(new { data = chosen_Company, success = true, message = "Process is success" });
        }
    }
}
