using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public double IdNumber { get; set; }
        public string JobTitle { get; set; }

        // FK
        [DisplayName("ID Number")]
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        // navigation property
        public Department Department { get; set; }
    }
}
