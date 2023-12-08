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

        // READ
        [HttpGet]
        public IActionResult GetEmployees() 
        {
            var employees = _db.Employees.Include(e => e.Department).ToList();

            return Ok(employees);
        }

        [HttpGet("{id}")]
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

        // CREATE
        [HttpPost]
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

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] Employee obj, int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Employee does not exist");
            }

            var employee = _db.Employees.Find(id);

            if (employee  == null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = obj.Name;
            employee.Surname = obj.Surname;
            employee.IdNumber = obj.IdNumber;
            employee.JobTitle = obj.JobTitle;
            employee.DepartmentId = obj.DepartmentId;

            _db.Employees.Update(employee);
            _db.SaveChanges();

            return Ok(employee);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Employee does not exist");
            }

            var employee = _db.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return Ok(_db.Employees.ToList());
        }
    }
}
