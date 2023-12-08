using EmployeeManagement.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Models;
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

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] Employee obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            var department = _db.Departments.Find(obj.DepartmentId);

            var employee = new Employee
            {
                EmployeeId = obj.EmployeeId,
                Name = obj.Name,
                Surname = obj.Surname,
                IdNumber = obj.IdNumber,
                JobTitle = obj.JobTitle,
                DepartmentId = obj.DepartmentId,
                DepartmentName = department.DepartmentName,
                Department = department
            };

            _db.Employees.Add(employee);
            _db.SaveChanges();

            var employees = _db.Employees.Include(e => e.Department).ToList();
            return Ok(employees);
        }
    }
}
