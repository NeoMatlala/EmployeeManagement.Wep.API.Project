using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ
        [HttpGet("GetDepartments", Name = "GetDepartments")]
        public IActionResult GetDepartments()
        {
            var departments = _db.Departments.ToList();
            return Ok(departments);
        }

        // READ single department
        [HttpGet("GetDepartment/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _db.Departments.Find(id);

            if(department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // CREATE
        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(Department obj)
        {
            if(obj == null)
            {
                return BadRequest("Invalid Data, try again please.");
            }

            var department = new Department
            {
                DepartmentName = obj.DepartmentName,
                Manager = obj.Manager,
                Members = obj.Members,
            };

            _db.Departments.Add(department);
            _db.SaveChanges();

            var departments = _db.Departments.ToList();
            return Ok(departments);
        }

        // UPDATE
        [HttpPost("UpdateDepartment/{id}")]
        public IActionResult UpdateDepartment(int id, Department obj)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid data");
            }

            var department = _db.Departments.Find(id);

            if (department == null)
            {
                return NotFound("Department not found");
            }

            department.DepartmentName = obj.DepartmentName;
            department.Manager = obj.Manager;
            department.Members = obj.Members;

            _db.SaveChanges();

            var departments = _db.Departments.ToList();

            return Ok(departments);
        }

        // DELETE
        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid");
            }

            var department = _db.Departments.Find(id);

            if(department == null)
            {
                return NotFound("Department not found");
            }

            _db.Departments.Remove(department);
            _db.SaveChanges();

            var departments = _db.Departments.ToList();

            return Ok(departments);
        }
    }
}
