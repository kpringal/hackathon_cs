using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class Office
    {
        public Office()
        {
            OfficeFloorDetail = new HashSet<OfficeFloorDetail>();
        }

        public Guid OfficeKey { get; set; }
        public string OfficeName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid RowVersion { get; set; }

        public virtual ICollection<OfficeFloorDetail> OfficeFloorDetail { get; set; }
    }
}
