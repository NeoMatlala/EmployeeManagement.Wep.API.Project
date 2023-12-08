using EmployeeManagement.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees() 
        {
            //var employees = _db.Employees.ToList();
            var employees = _db.Employees.Include(e => e.Department).ToList();

            return Ok(employees);
        }
    }
}
