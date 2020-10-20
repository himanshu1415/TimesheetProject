using System;
using System.Collections.Generic;

namespace AdminDetails.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AdminEmployee = new HashSet<AdminEmployee>();
        }

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<AdminEmployee> AdminEmployee { get; set; }
    }
}
