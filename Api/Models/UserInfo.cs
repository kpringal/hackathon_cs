using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            LoginInfo = new HashSet<LoginInfo>();
            UserRoleMaster = new HashSet<UserRoleMaster>();
        }

        public Guid UserKey { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Oecode { get; set; }
        public Guid? ManagerKey { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid RowVersion { get; set; }

        public virtual ICollection<LoginInfo> LoginInfo { get; set; }
        public virtual ICollection<UserRoleMaster> UserRoleMaster { get; set; }
    }
}
