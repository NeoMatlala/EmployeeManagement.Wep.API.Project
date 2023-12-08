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
            var employees = _db.Employees.Include(e => e.Department).ToList();

            return Ok(employees);
        }

        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {

            if(id == 0 || id == null)
            {
                return BadRequest("User does not exist");
            }

            var employee = _db.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
