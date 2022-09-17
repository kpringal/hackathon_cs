using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class UserRoleMaster
    {
        public Guid UserRoleKey { get; set; }
        public Guid UserKey { get; set; }
        public Guid RoleKey { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid RowVersion { get; set; }

        public virtual RoleMaster RoleKeyNavigation { get; set; }
        public virtual UserInfo UserKeyNavigation { get; set; }
    }
}
