using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HRManagementMVCCore31DapperWebApp1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        //public IEnumerable<Department> DepartmentList { get; set; }
        public virtual string DepartmentName { get; set; }
        //public Department Department { get; set; }
        //public virtual List<Department> DepartmentList { get; set; }
    }    
}
