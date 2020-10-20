using System;
using System.Collections.Generic;

namespace AdminDetails.Models
{
    public partial class Userlogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
