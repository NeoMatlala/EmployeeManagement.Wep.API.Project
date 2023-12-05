using System.ComponentModel;

namespace EmployeeManagement.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        public string Manager { get; set; }
        public int Members { get; set; }

        //navigation property
        //public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
