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

        // get departments
        [HttpGet("GetDepartments", Name = "GetDepartments")]
        public IActionResult GetDepartments()
        {
            var departments = _db.Departments.ToList();
            return Ok(departments);
        }

        // get single department
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
    }
}
