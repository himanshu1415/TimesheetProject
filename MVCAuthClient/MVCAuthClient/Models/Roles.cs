using System;
using System.Collections.Generic;

namespace MVCAuthClient.Models
{
    public partial class Roles
    {
        public Roles()
        {
            AdminEmployee = new HashSet<AdminEmployee>();
            Employee = new HashSet<Employee>();
            Userlogin = new HashSet<Userlogin>();
        }

        public int RoleId { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<AdminEmployee> AdminEmployee { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Userlogin> Userlogin { get; set; }
    }
}
