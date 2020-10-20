using System;
using System.Collections.Generic;

namespace Timesheet.Models
{
    public partial class AdminEmployee
    {
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string Gender { get; set; }
        public string EmployeeId { get; set; }
        public int? RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Roles Role { get; set; }
    }
}
